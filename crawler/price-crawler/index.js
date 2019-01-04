"use strict";

const puppeteer = require("puppeteer");
const utility = require("../utility.js");

(async () => {
    let merchants = require("./merchant");
    const browser = await puppeteer.launch({
        headless: false,
        ignoreHTTPSErrors: true
    });
    merchants.forEach(merchant => crawlMerchant(browser, merchant));
})();

async function crawlMerchant(browser, merchant) {
    const page = await browser.newPage();
    await page.setJavaScriptEnabled(false);
    await page.setViewport({width: 1920, height: 1080});
    
    merchant.links.reduce((promiseChain, part) => 
        promiseChain.then(() => crawlPart(page, merchant, part)), Promise.resolve()
    )
}

async function crawlPart(page, merchant, part) {
    var priceList = [];
    await utility.openPage(page, merchant.homePage + part.URL, {waitUntil: "domcontentloaded"});

    let pageCount = await page.evaluate(merchant.getPageCount);
    console.log("pageCount : " + pageCount);

    for (var i = 1; i <= pageCount; i++) {
        await utility.openPage(page, merchant.homePage + part.URL + `?page=${i}`, {waitUntil: "domcontentloaded"})
        var pagePriceList = await getPageData(page, merchant.evaluate);
        console.log(pagePriceList);
        if (typeof part.format !== "undefined") pagePriceList.forEach(part.format);

        priceList.push(...pagePriceList);
    }
    
    utility.writeToJson(`data/${merchant.name}`, part.partType, priceList);
}

async function getPageData(page, evaluate) {
    return await page.evaluate(evaluate);
}