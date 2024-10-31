function loadRepos() {
	const GET_URL = 'https://api.github.com/users';
	const id = document.getElementById('username').value;
	const listEl = document.getElementById('repos');

	function createLiElement(repo, error){
		const liEl = document.createElement('li');
		const linkEl = document.createElement('a');
		
		if(error){
			linkEl.textContent = error;	
		} else {
			linkEl.textContent = repo.full_name;
			linkEl.href = repo.html_url;
		}			
		
		liEl.appendChild(linkEl);
		listEl.appendChild(liEl);
	}

	fetch(`${GET_URL}/${id}/repos`)
		.then((response) => response.json())
		.then((data) => {
			listEl.innerHTML = '';	
			[...data].forEach((repo) => {
				createLiElement(repo);
			})
		})
		.catch((error) => {
			createLiElement({}, error);
		});
}