function loadRepos() {
    const GET_URL = 'https://api.github.com/users/testnakov/repos';

    const divEl = document.getElementById('res');
    
    fetch(GET_URL)
        .then((body) => body.text())
        .then((data) => divEl.textContent = data)
        .catch((error) => console.log(error));
}