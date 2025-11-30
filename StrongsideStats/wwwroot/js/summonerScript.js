async function getSummoner() {
    const params = new URLSearchParams(document.location.search);

    try {
        const response = await fetch(`https://localhost:7108/api/summoners/by-riot-id?gameName=${params.get("gameName")}&tagLine=${params.get("tagLine")}`);
        if (response.status == 200) {
            const data = await response.json();
            createPlayerInfo(data, true);
        }
        else if(response.status == 404) {
            createPlayerInfo({}, false);
        }
        else if (!response.ok) {
            throw new Error('Could not fetch resource');
        }
    }
    catch (error) {
        console.error('Error fetching data:', error);
    }
}

function createPlayerInfo(data, success) {
    const info = document.createElement("div");

    if (success) {
        const queueType = document.createElement("div");
        queueType.textContent = data["leaguesDTO"][0]["queueType"];

        info.append(queueType);
    }
    else {
        info.textContent = "Not found";
    }

    const container = document.getElementById("container");
    container.append(info);
}

getSummoner();