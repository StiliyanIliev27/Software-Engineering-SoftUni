function create(words) {
   const divElement = document.getElementById('content');
   
   function createDivElements(words){
      words.forEach((word) => {
         const paragraph = document.createElement('p');
         const div = document.createElement('div');
         
         paragraph.textContent = word;
         paragraph.style.display = 'none';
        
         div.appendChild(paragraph);
        
         div.addEventListener('click', (e) => {
            const currentDivEl = e.currentTarget;
            currentDivEl.querySelector('p').style.display = 'block';
         })
        
         divElement.appendChild(div);
      });
   }

   createDivElements(words);
}