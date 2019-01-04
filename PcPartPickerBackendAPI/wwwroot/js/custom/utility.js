async function getJson(api) {
    let host = "https://localhost:5001/";
    let response = await fetch(host + api, {
        mode: "cors",
        method: "GET",
        headers: {
            "Access-Control-Allow-Origin": "*"
        }
    })
    return await response.json();
}

async function postJson(data, api) {
    let host = "https://localhost:5001/";
    let response = await fetch(host + api, {
        mode: "cors",
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=utf-8'
        },
        body: JSON.stringify(data)
    })
    return await response.json();
}