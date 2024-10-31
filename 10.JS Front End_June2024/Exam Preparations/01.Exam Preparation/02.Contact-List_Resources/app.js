window.addEventListener("load", solve);

function solve() {
    const addButton = document.getElementById('add-btn');    

    const checkList = document.getElementById('check-list');
    const contactList = document.getElementById('contact-list');

    let nameInputEl = document.getElementById('name');
    let phonenumberEl = document.getElementById('phone');
    let categoryEl = document.getElementById('category');

    function clearInputs(){
        nameInputEl.value = '';
        phonenumberEl.value = '';
        categoryEl.value = '';
    }

    function addCheckListItems(){
        const name = nameInputEl.value;
        const phoneNumber = phonenumberEl.value;
        const category = categoryEl.value;

        const articleEl = addArticle(name, phoneNumber, category);

        const editButtonEl = document.createElement('button');
        editButtonEl.classList.add('edit-btn');
        const saveButtonEl = document.createElement('button');
        saveButtonEl.classList.add('save-btn');

        const divButtonsEl = document.createElement('div');
        divButtonsEl.classList.add('buttons');
        divButtonsEl.appendChild(editButtonEl);
        divButtonsEl.appendChild(saveButtonEl);

        const liEl = document.createElement('li');
        liEl.appendChild(articleEl);
        liEl.appendChild(divButtonsEl);

        checkList.appendChild(liEl);

        clearInputs();

        function editContact(){
            nameInputEl.value = name;
            phonenumberEl.value = phoneNumber;
            categoryEl.value = category;

            liEl.remove();
        }

        function saveContact(){
            const [name, phoneNumber, category] = [...document.querySelectorAll('p')];
            const article = addArticle(name.textContent, 
                phoneNumber.textContent, category.textContent);
            
            const deleteButton = document.createElement('button');
            deleteButton.classList.add('del-btn');
            
            const liElement = document.createElement('li');
            liElement.appendChild(article);
            liElement.appendChild(deleteButton);

            contactList.appendChild(liElement);
            
            liEl.remove();
            editButtonEl.remove();
            saveButtonEl.remove();

            function deleteContact(){
                liElement.remove();
            }

            deleteButton.addEventListener('click', deleteContact);
        }

        editButtonEl.addEventListener('click', editContact);
        saveButtonEl.addEventListener('click', saveContact);
    }

    function addArticle(name, phoneNumber, category){
        const pNameEl = document.createElement('p');
        pNameEl.textContent = `name:${name}`;

        const pPhoneNumberEl = document.createElement('p');
        pPhoneNumberEl.textContent = `phone:${phoneNumber}`;

        const pCategoryEl = document.createElement('p');
        pCategoryEl.textContent = `category:${category}`;

        const articleEl = document.createElement('article');
        articleEl.appendChild(pNameEl);
        articleEl.appendChild(pPhoneNumberEl);
        articleEl.appendChild(pCategoryEl);

        return articleEl;
    }

    addButton.addEventListener('click', addCheckListItems);
}