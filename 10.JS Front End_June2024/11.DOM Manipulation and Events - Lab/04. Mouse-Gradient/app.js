function attachGradientEvents() {
    const resultElement = document.getElementById('result');
    const gradientElement = document.getElementById('gradient');

    gradientElement.addEventListener('mousemove', (e) => {
        const currentPosition = e.offsetX;
        const elemenetWidth = e.currentTarget.clientWidth;

        const percent = Math.floor((currentPosition / elemenetWidth) * 100);

        resultElement.textContent = `${percent}%`;
    });
}