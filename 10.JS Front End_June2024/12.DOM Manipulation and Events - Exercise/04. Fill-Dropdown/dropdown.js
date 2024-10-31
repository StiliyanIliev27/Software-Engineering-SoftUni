function addItem() {
    const selectEl = document.getElementById('menu');
    const newItemTextEl = document.getElementById('newItemText');
    const newItemValueEl = document.getElementById('newItemValue');

    function clear(){
        newItemTextEl.value = '';
        newItemValueEl.value = '';
    }

    const optionEl = document.createElement('option');
    optionEl.textContent = newItemTextEl.value;
    optionEl.value = newItemValueEl.value;

    selectEl.appendChild(optionEl);
    clear();
}