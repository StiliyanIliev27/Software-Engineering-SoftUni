function encodeAndDecodeMessages() {
    const encodeButtonEl = document.querySelector('div:nth-child(1) button');
    const decodeButtonEl = document.querySelector('div:nth-child(2) button');
    
    function decodeMessage(){
        const encodeMessageEl = document.querySelector('div:nth-child(1) textarea');
        const decodeMessageEl = document.querySelector('div:nth-child(2) textarea');
        
        const encodeMessage = encodeMessageEl.value;
        let decodedMessage = '';

        [...encodeMessage].forEach((letter) => {
            const newCurrentLetterCharCode = letter.charCodeAt(0) + 1;
            decodedMessage += String.fromCharCode(newCurrentLetterCharCode);
        });
        
        encodeMessageEl.value = '';
        decodeMessageEl.value = decodedMessage;
    }

    function encodeMessage(){
        const decodeMessageEl = document.querySelector('div:nth-child(2) textarea');

        let encodedMessage = '';

        [...decodeMessageEl.value].forEach((letter) => {
            const newCurrentLetterCharCode = letter.charCodeAt(0) - 1;
            encodedMessage += String.fromCharCode(newCurrentLetterCharCode);
        })

        decodeMessageEl.value = encodedMessage;
    }

    encodeButtonEl.addEventListener('click', decodeMessage);
    decodeButtonEl.addEventListener('click', encodeMessage); 
}