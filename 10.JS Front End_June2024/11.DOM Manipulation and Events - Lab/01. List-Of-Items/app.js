function addItem() {
    const inputText = document.querySelector('input[type="text"]').value;
    const itemsList = document.getElementById('items');
    const liEl = document.createElement('li');
    liEl.textContent = inputText;
    itemsList.appendChild(liEl);
}