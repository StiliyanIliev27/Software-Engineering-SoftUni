function validate() {
    const inputEl = document.getElementById('email');
    const pattern = /[a-z]+@[a-z]+\.[a-z]+/g;

    inputEl.addEventListener('change', (e) => {
        if(!pattern.test(e.currentTarget.value)){
            return e.currentTarget.classList.add('error');
        }
        e.currentTarget.classList.remove('error');
    })
}