function loadCommits() {
    const username = document.getElementById('username').value;
    const repo = document.getElementById('repo').value;
    const ulEl = document.getElementById('commits');
    const GET_URL = `https://api.github.com/repos/${username}/${repo}/commits`;

    fetch(GET_URL)
        .then((response) => response.json())
        .then((data) => {
            [...data].forEach((element) => {
                const liEl = document.createElement('li');
                
                const author = element.commit.author.name;
                const message = element.commit.message;
                
                liEl.textContent = `${author}: ${message}`;
                ulEl.appendChild(liEl);
            });         
        })
        .catch((error) => {
            const liEl = document.createElement('li');

            liEl.textContent = `Error: ${error.status} (Not Found)`;

            ulEl.appendChild(liEl);
        });
}