function deleteByEmail() {
    const emailInput = document.querySelector('input[type="text"]').value;
    const emails = document.querySelectorAll('tr td:nth-child(2)');
    const result = document.getElementById('result');
    emails.forEach((email) => {
        if(emailInput !== email.textContent){
            result.textContent = 'Not found.';
            return;
        }
        const row = email.parentNode;
        row.parentNode.removeChild(row);
        result.textContent = 'Deleted';
    });
}