const merchants = [/*{
    "name": "An Phat Computer",
    "homePage": "https://www.anphatpc.com.vn/",
    "getPageCount": () => {
        let pages = document.querySelector(".paging").children;
        return parseInt(pages[pages.length-2].innerText);
    },
    "evaluate" : () => {
        let items = document.querySelectorAll(".p_container");
        return [...items].map(node => {
            return {
                "price" : parseInt(node.querySelector(".p_price>i").innerText.split('.').join('')),
                "name" : node.querySelector(".p_name").innerText.replace(/-/g," "),
                "inStock" : node.querySelector(".p-act>.fl").innerText === "Còn hàng",
                "date" : new Date().toISOString().slice(0, -1).replace("T"," ")
            }
        })
    },
    "links": [
        {
            "partType": "cpu",
            "URL": "cpu-desktop_dm1025.html",
            "format": (data) => {
                data.name = data.name
                .replace(/-/g, " ")
                .replace(/\s+/gi," ")
                .replace('CPU','')
                .trim()
            }
        }, {
            "partType": "gpu",
            "URL": "vga-card-man-hinh_dm1155.html"
        }, {
            "partType": "motherboard",
            "URL": "bo-mach-chu_dm1024.html"
        }, {
            "partType": "memory",
            "URL": "bo-nho-trong_dm1234.html",
            "format": (data) => {
                data.name = data.name
                .replace(/-/g, " ")
                .replace(/\s+/gi," ")
                .trim()
            }
        }, {
            "partType": "storage",
            "URL": "o-cung-hdd-ssd_dm1314.html"
        }, {
            "partType": "psu",
            "URL": "nguon-dien-may-tinh-psu_dm1051.html"
        }, {
            "partType": "case",
            "URL": "vo-may-tinh-case_dm1050.html"
        }
    ]
},{
    "name": "Hanoi Computer",
    "homePage": "https://www.hanoicomputer.vn/",
    "evaluate" : () => {
        let items = document.querySelectorAll(".p_container");
        return [...items].map(node => {
            return {
                "price" : parseInt(node.querySelector(".p_price").innerText.split('.').join('')),
                "name" : node.querySelector(".p_name").innerText.replace(/-/g," "),
                "inStock" : node.querySelector(".p_quantity>i").className.includes("in_stock"),
                "date" : new Date().toISOString().slice(0, -1).replace("T"," ")
            }
        })
    },
    "links": [
        {
            "partType": "cpu",
            "URL": "bo-vi-xu-ly/c31.html",
            "format": (data) => {
                data.name = data.name
                .replace(/-/g, " ")
                .replace(/\s+/gi," ")
                .trim()
            }
        }, {
            "partType": "gpu",
            "URL": "card-man-hinh/c34.html"
        }, {
            "partType": "motherboard",
            "URL": "bo-mach-chu/c30.html"
        }, {
            "partType": "memory",
            "URL": "bo-nho-trong/c32.html",
            "format": (data) => {
                data.name = data.name
                .replace(/-/g, " ")
                .replace(/\s+/gi," ")
                .trim()
            }
        }, {
            "partType": "ssd",
            "URL": "o-the-ran-ssd/c164.html"
        },{ 
            "partType": "hdd",
            "URL": "o-cung-hdd/c33.html"
        },{
            "partType": "psu",
            "URL": "nguon-may-tinh/c36.html"
        }, {
            "partType": "case",
            "URL": "vo-case/c35.html"
        }
    ]
},*/{
    "name": "Mai Hoang",
    "homePage": "http://maihoang.com.vn/",
    "getPageCount": () => {
        let pages = document.querySelector(".pagination").children;
        return parseInt(pages[pages.length-3].innerText);
    },
    "evaluate" : () => {
        let items = document.querySelectorAll(".pro-item");
        return [...items].map(node => {

            let anchor = node.querySelector("h2>a");

            return {
                "price" : parseInt(node.querySelector(".pro-price").innerText.split(',').join('')),
                "name" : 'part : ' + anchor.innerText.replace(/-/g, ' ') + ' ',
                "inStock" : false,
                "date" : new Date().toISOString().slice(0, -1).replace("T"," "),
                "url": anchor.href
            }
        })
    },
    "links": [
        {
            "partType": "cpu",
            "URL": "cpu-bo-vi-xu-ly",
            "format": (data) => {
                data.name = data.name
                .replace('Pentium G5400', "Pentium Gold G5400")
                .replace('Pentium G5500', "Pentium Gold G5400")
                .replace('Processor',"")
                .replace(/[®™]/g, " ")
                .replace(/\s+/gi," ")
                .trim()
            }
        }, {
            "partType": "gpu",
            "URL": "vga-card-man-hinh"
        }, {
            "partType": "motherboard",
            "URL": "main-bo-mach-chu"
        }, {
            "partType": "memory",
            "URL": "ram-bo-nho-trong"
        }, {
            "partType": "ssd",
            "URL": "o-cung-hdd-ssd"
        },{ 
            "partType": "hdd",
            "URL": "o-cung-hdd"
        },{
            "partType": "psu",
            "URL": "psu-nguon-may-tinh"
        }, {
            "partType": "case",
            "URL": "case-vo-may-tinh"
        }
    ]
}];

module.exports = merchants;