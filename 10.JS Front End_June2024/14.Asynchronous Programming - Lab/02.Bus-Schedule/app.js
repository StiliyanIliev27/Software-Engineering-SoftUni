function solve() {
    const GET_URL = 'http://localhost:3030/jsonstore/bus/schedule';
    const inputEl = document.getElementById('info');
    const arriveButton = document.getElementById('arrive');
    const departButton = document.getElementById('depart');
    let busId = 'depot';
    let currentStop = null;

    function depart() {
        arriveButton.disabled = false;
        departButton.disabled = true;
        fetch(`${GET_URL}/${busId}`)
            .then((response) => response.json())
            .then((data) => {
                currentStop = data.name;
                busId = data.next;     
                inputEl.textContent = `Next stop ${currentStop}`;
            })
            .catch((error) => console.log(error));
        
    }

    async function arrive() {
        arriveButton.disabled = true;
        departButton.disabled = false;
        inputEl.textContent = `Arriving at ${currentStop}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();