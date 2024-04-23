
let searchBtnUpdate = document.querySelector('.phone-panel__btn-update');
let searchLinkUpdate = document.querySelector('.a-update');
let searchInput = document.querySelectorAll('.phone-panel__textbox');

attr = document.createAttribute("readonly");
searchLinkUpdate.addEventListener('click', function ()
{
    searchLinkUpdate.classList.add('a-update__action');
    searchLinkCancel.classList.remove('a-cancel__action');
    searchBtnUpdate.classList.add('btn-update__action');
    for (el of searchInput) {
      //  el.removeAttributeNode(attr);
        el.removeAttribute("readonly");
    }
});
let searchLinkCancel = document.querySelector('.a-cancel');
searchLinkCancel.addEventListener('click', function () {
    searchLinkCancel.classList.add('a-cancel__action');
    searchLinkUpdate.classList.remove('a-update__action');
    searchBtnUpdate.classList.remove('btn-update__action'); 
    for (el of searchInput) {
       // el.setAttributeNode(attr);
        el.setAttribute("readonly","");
    }
    
    
})


