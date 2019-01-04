"use strict";

const utility = require("../utility");

(async () => {   
<<<<<<< HEAD:crawler/index.js
    let partType = [/*{
        name : 'cpu'      
    },{
        name: 'video-card'
    },{
        name : 'motherboard'
    },{
        name : 'memory',
        format : (part) => {
            delete part["PRICE/GB"];
            return part
        }
    }/*,*/{
    //     name : 'storage',
    //     format : (part) => {
    //         delete part['GB/$1.00'];
    //         delete part['PRICE/GB'];
    //         return part
    //     }
    // },{
        // name : 'power-supply'
    // },
    // ,{
        name : 'case'
    }]

=======
    const puppeteer = require('puppeteer');
    const partType = require("./partType.js");
>>>>>>> develop:crawler/part-crawler/index.js
    const browser = await puppeteer.launch({headless: false});

    partType.reduce((promiseChain, type) => 
        promiseChain.then(() => crawl(browser, type)), Promise.resolve()
    )
})();

async function crawl(browser, type) {
    var page = await browser.newPage();

        var partLinkList = [];
        await page.goto('https://pcpartpicker.com/products/' + type.name, { waitUntil: 'networkidle0' });
        let links = await getLinks(page);
        partLinkList.push(...links);

        var pageCount = await page.evaluate(() => {
            let pageRows = document.querySelectorAll('.page-button>a');
            return pageRows[pageRows.length-1].innerText;
        })

        for (let i = 2; i <= pageCount; i++ ) {
            await page.goto(`https://pcpartpicker.com/products/${type.name}/#page=${i}`);
            await page.waitForResponse(resp => resp.status() === 200)
            let links = await getLinks(page);
            partLinkList.push(...links);
        }

        const partList = await getPartList(page, type.format, partLinkList);
        utility.writeToJson("data", type.name, partList);
}

async function getLinks(page) {
    console.log(page.url());
    const links = await page.evaluate(() => {
        let partLink = document.querySelectorAll('.tdname > a');
        partLink = [...partLink];
        let partLinkList = partLink.map(part => ({
            link: part.getAttribute('href'),
            name: part.innerText.replace('-',' ')
        }));
        return partLinkList;
    }).catch();

    return links;
}

async function getPartList(page, format, partLinkList) {
    console.log(`Total part is : ${partLinkList.length}`);
    var partList = [];

    for (let element of partLinkList) {
        let crawlDelay = getRandomArbitrary(1000, 2000);
        await page.waitFor(crawlDelay);
        await utility.openPage(page, "https://pcpartpicker.com" + element.link, { waitUntil : 'domcontentloaded' })
        
        let part = await page.evaluate(() => {
            var specs = document.querySelector("div.specs.block").childNodes;
            var part = {}; 

            for (var i = specs.length-1; i > 2; i -= 2) {
                let specName = specs[i-1].innerText;
                let specValue = specs[i].nodeValue.trim();

                if (specName === "\n") {
                    specs[i-2].nodeValue += `, ${specValue.replace('(or) ','')}`;
                } else {
                    part[specName] = specValue;
                }
            }

            var images = document.querySelectorAll('.owl-item>a>img');
            var links = [...images].map(img => img.getAttribute('src'));
            part['IMAGES'] = links;
            
            return part;
        });

        part['NAME'] = element.name.replace(/-/g, " ");
        partList.push(typeof format === 'undefined' ? part : format(part));
        console.log(partList[partList.length-1]);
    }

    return await partList;
}

function getRandomArbitrary(min, max) {
    return Math.random() * (max - min) + min;
  }