function addItem() {
    const inputText = document.querySelector('input[type="text"]').value;
    const itemsList = document.getElementById('items');
    const liEl = document.createElement('li');
    liEl.textContent = inputText;

    const deleteButtonEl = document.createElement('a');
    deleteButtonEl.textContent = '[Delete]';
    deleteButtonEl.href = '#';
    liEl.append(deleteButtonEl);

    itemsList.appendChild(liEl);

    deleteButtonEl.addEventListener('click', (e) => {
        e.currentTarget.parentElement.remove();
    });
}