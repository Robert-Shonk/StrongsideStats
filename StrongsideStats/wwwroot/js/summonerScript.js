const baseUrl = 'https://localhost:7108/api/summoners';

const params = new URLSearchParams(window.location.search);

async function fetchSummoner() {
    try {
        const response = await fetch(`${baseUrl}/by-riot-id?gameName=${params.get("gameName")}&tagLine=${params.get("tagLine")}`);
        if (response.status == 404) {
            console.log("handle 404");
            // render page for no summoner found in db.
        }
        else if (response.status == 200) {
            // render page for success summoner found.
            console.log("handle 200 success");
        }
        else if (!response.ok) {
            throw new Error(`Response status: ${response.status}`);
        }
    }
    catch (error) {
        console.error(error.message);
    }
}

async function postUpdateSummoner() {
    try {
        const response = await fetch(`${baseUrl}/update-summoner`, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ gameName: params.get("gameName"), tagLine: params.get("tagLine") })
        });
        if (!response.ok) {
            throw new Error(`Response status: ${response.status}`);
        }

        return true;
    }
    catch (error) {
        console.error('Error posting data:', error);
    }
}

const updateButton = document.getElementById("updateButton");
updateButton.addEventListener('click', async () => {
    const postRequest = await postUpdateSummoner();

    if (postRequest) {
        fetchSummoner();
    }
});