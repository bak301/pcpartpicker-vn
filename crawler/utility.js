async function writeToJson(subfolder, filename, data) {
    let fs = require('fs');
    if (!fs.existsSync(subfolder)) fs.mkdirSync(subfolder);
    let fullPath = `${subfolder}/${filename}.json`;
    await fs.writeFile(fullPath, JSON.stringify(data, null, "\t"), (err) => {
        if (err) throw  err;
        console.log(`${data.length} ${filename} has been write to ${fullPath}`);
    });
}

async function openPage(page, link, options) {
    var response;

    try {
        response = await page.goto(link, options);
    } catch (ex) {
        console.log(ex);
        response = await openPage(page, link, options);
    }

    return response;
}

module.exports.writeToJson = writeToJson;
module.exports.openPage = openPage;