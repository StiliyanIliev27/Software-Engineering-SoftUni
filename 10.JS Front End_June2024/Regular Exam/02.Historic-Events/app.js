window.addEventListener("load", solve);

function solve() {
    const previewList = document.querySelector('#events .event-section #preview-list');
    const archiveList = document.getElementById('archive-list');

    const addButton = document.getElementById('add-btn');

    const nameInputEl = document.getElementById('name');
    const timeInputEl = document.getElementById('time');
    const descriptionInputEl = document.getElementById('description');

    function clearInputFields(){
        nameInputEl.value = '';
        timeInputEl.value = '';
        descriptionInputEl.value = '';
    }

    function addArticle(name, time, description){
        const pNameEl = document.createElement('p');
        pNameEl.textContent = name;

        const pTimeEl = document.createElement('p');
        pTimeEl.textContent = time;

        const pDescriptionEl = document.createElement('p');
        pDescriptionEl.textContent = description;

        const article = document.createElement('article');
        article.appendChild(pNameEl);
        article.appendChild(pTimeEl);
        article.appendChild(pDescriptionEl);

        return article;
    }

    function addPreviewList(){
        const name = nameInputEl.value;
        const time = timeInputEl.value;
        const description = descriptionInputEl.value;

        const article = addArticle(name, time, description);

        const divButtonsEl = document.createElement('div');
        divButtonsEl.classList.add('buttons');

        const editButton = document.createElement('button');
        editButton.classList.add('edit-btn');
        editButton.textContent = 'Edit';

        const nextButton = document.createElement('button');
        nextButton.classList.add('next-btn');
        nextButton.textContent = 'Next';

        divButtonsEl.appendChild(editButton);
        divButtonsEl.appendChild(nextButton);

        const liEl = document.createElement('li');
        liEl.appendChild(article);
        liEl.appendChild(divButtonsEl);

        previewList.appendChild(liEl);

        clearInputFields();
        addButton.disabled = true;

        function editInfo(){
            nameInputEl.value = name;
            timeInputEl.value = time;
            descriptionInputEl.value = description;

            liEl.remove();
            addButton.disabled = false;
        }

        function next(){
            const article = addArticle(name, time, description);

            const archiveButton = document.createElement('button');
            archiveButton.classList.add('archive-btn');
            archiveButton.textContent = 'Archive';

            const li = document.createElement('li');
            li.appendChild(article);
            li.appendChild(archiveButton);

            archiveList.appendChild(li);
            liEl.remove();
            editButton.remove();
            nextButton.remove();

            function archive(){
                li.remove();
                addButton.disabled = false;
            }

            archiveButton.addEventListener('click', archive);
        }

        editButton.addEventListener('click', editInfo);
        nextButton.addEventListener('click', next);
    }

    addButton.addEventListener('click', addPreviewList);
}