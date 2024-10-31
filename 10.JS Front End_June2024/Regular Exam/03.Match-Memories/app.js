const baseUrl = 'http://localhost:3030/jsonstore/matches';

const loadMatchesButton = document.getElementById('load-matches');
const addMatchButton = document.getElementById('add-match');
const editMatchButton = document.getElementById('edit-match');
const formElement = document.querySelector('#form form');

const listMatches = document.getElementById('list');

const teamHostInputEl = document.getElementById('host');
const teamGuestInputEl = document.getElementById('guest');
const scoreInputEl = document.getElementById('score');

function clearInputFields(){
    teamHostInputEl.value = '';
    teamGuestInputEl.value = '';
    scoreInputEl.value = '';
}

async function loadMatches(){
    listMatches.innerHTML = '';

    const response = await fetch(baseUrl);
    const result = await response.json();
    const matches = Object.values(result);
    
    const matchesElements = matches.map(match => createLiMatchElements(match.host, match.score, match.guest, match._id));
    
    listMatches.append(...matchesElements);
    editMatchButton.disabled = true;
}

function createLiMatchElements(host, score, guest, matchId){
    const liEl = document.createElement('li');
    liEl.classList.add('match');

    const divEl = document.createElement('div');
    divEl.classList.add('info');

    const pHost = document.createElement('p');
    pHost.textContent = host;
    
    const pScore = document.createElement('p');
    pScore.textContent = score;
   
    const pGuest = document.createElement('p');
    pGuest.textContent = guest;

    divEl.appendChild(pHost);
    divEl.appendChild(pScore);
    divEl.appendChild(pGuest);

    const divButtonsEl = document.createElement('div');
    divButtonsEl.classList.add('btn-wrapper');
    
    const changeButton = document.createElement('button');
    changeButton.classList.add('change-btn');
    changeButton.textContent = 'Change';
    changeButton.addEventListener('click', () => {
        
        teamHostInputEl.value = host;
        scoreInputEl.value = score;
        teamGuestInputEl.value = guest;

        editMatchButton.removeAttribute('disabled');

        addMatchButton.setAttribute('disabled', 'disabled');

        formElement.setAttribute('data-match-id', matchId);
    });

    const deleteButton = document.createElement('button');
    deleteButton.classList.add('delete-btn');
    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener('click', async () => {
        await fetch(`${baseUrl}/${matchId}`, {
            method: 'DELETE',
        });

        await loadMatches();
    })

    divButtonsEl.appendChild(changeButton);
    divButtonsEl.appendChild(deleteButton);

    liEl.appendChild(divEl);
    liEl.appendChild(divButtonsEl);

    return liEl;
}

async function addMatch() {
    listMatches.innerHTML = '';

    const host = teamHostInputEl.value;
    const guest = teamGuestInputEl.value;
    const score = scoreInputEl.value;

    clearInputFields();

    await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({host, score, guest})
    })

    await loadMatches(); 
}

async function editMatch() {
    const matchId = formElement.getAttribute('data-match-id');

    const host = teamHostInputEl.value;
    const score = scoreInputEl.value;
    const guest = teamGuestInputEl.value;

    clearInputFields();

    await fetch(`${baseUrl}/${matchId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ host, score, guest, _id: matchId }),
    });

    await loadMatches();

    editMatchButton.setAttribute('disabled', 'disabled');

    editMatchButton.removeAttribute('disabled');

    formElement.removeAttribute('data-match-id');
}

loadMatchesButton.addEventListener('click', loadMatches);
addMatchButton.addEventListener('click', addMatch);
editMatchButton.addEventListener('click', editMatch);