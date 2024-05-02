
let BtnUpdate = document.querySelector('.phone-panel__btn-update');
let LinkUpdate = document.querySelector('.a-update');
let Input = document.querySelectorAll('.phone-panel__textbox');

attr = document.createAttribute("readonly");
LinkUpdate.addEventListener('click', function ()
{
    LinkUpdate.classList.add('a-update__action');
    LinkCancel.classList.remove('a-cancel__action');
    BtnUpdate.classList.add('btn-update__action');
    for (el of Input) {
      //  el.removeAttributeNode(attr);
        el.removeAttribute("readonly");
    }
});
let LinkCancel = document.querySelector('.a-cancel');
LinkCancel.addEventListener('click', function () {
    LinkCancel.classList.add('a-cancel__action');
    LinkUpdate.classList.remove('a-update__action');
    BtnUpdate.classList.remove('btn-update__action'); 
    for (el of Input) {
       // el.setAttributeNode(attr);
        el.setAttribute("readonly","");
    }
    
    
})


    
