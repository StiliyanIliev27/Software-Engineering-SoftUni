function lockedProfile() {
    function onClickHandler(event){
        const radioButton = event.target.parentElement.querySelector('input[type=radio]');
        const showMoreButton = event.target;
        const hiddenInformationEl = event.target.parentElement.querySelector('.profile div');

        if(radioButton.checked){
            return;
        }

        if(showMoreButton.textContent === 'Hide it'){
            showMoreButton.textContent = 'Show more';
            hiddenInformationEl.style.display = 'none';
        } else {
            showMoreButton.textContent = 'Hide it';
            hiddenInformationEl.style.display = 'block';
        }
    }

    document.querySelectorAll('.profile button').forEach((button) => {
        button.addEventListener('click', onClickHandler);
    });
}