function solve() {
   const buttons = Array.from(document.querySelectorAll('.product .product-add .add-product'));
   const checkoutButton = document.querySelector('.checkout');
   const output = document.querySelector('textarea');
   const products = [];

   buttons.forEach(button => {
      button.addEventListener('click', (e) => {
         const currentProductRow = e.currentTarget.parentElement.parentElement;
         
         const details = currentProductRow.children[1].querySelector('.product-title').textContent;
         const price = currentProductRow.children[3].textContent;
        
         const productEl = {
            details,
            price: Number(price)
         };
         products.push(productEl);
      
         output.textContent += `Added ${productEl.details} for ${productEl.price.toFixed(2)} to the cart.\n`;
         })
   });

   function onlyUnique(value, index, array) {
      return array.indexOf(value) === index;
   }

   checkoutButton.addEventListener('click', () => {
      let totalPrice = 0;
      let productsList = [];
      
      for(let product of products){
         totalPrice += product.price;
         productsList.push(product.details);
      }

      const productsListText = productsList.filter(onlyUnique).join(', ').trim();

      output.textContent += `You bought ${productsListText} for ${totalPrice.toFixed(2)}.`;

      buttons.forEach(button => {
         button.disabled = true;
         checkoutButton.disabled = true;
      })
   });
}