function focused() {
    const inputElements = document.querySelectorAll('input[type=text]');

    inputElements.forEach(el => {
        el.addEventListener('focus', (e) => {
            const currentEl = e.currentTarget.parentElement;
            currentEl.classList.add('focused');         
        });
    });

    inputElements.forEach(el => {
        el.addEventListener('blur', (e) => {
            const currentEl = e.currentTarget.parentElement;
            currentEl.classList.remove('focused');         
        });
    });
}