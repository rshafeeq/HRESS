function showContextMenu(messageText) {
    var menuContent = '';

    if ((messageText != null) && (messageText.length > 0))
        menuContent = messageText;
    else
        menuContent = 'There is no additional information available for this item.'

    var menuWidth = 500;
    var menuHeight = menuContent.length;

    var menuLeft = event.clientX - menuWidth;
    var menuTop = event.clientY - menuHeight;

    var popupMenu = window.createPopup();
    var popupMenuBody = popupMenu.document.body;

    popupMenuBody.style.backgroundColor = 'Yellow';
    popupMenuBody.style.border = 'solid black 2px';
    popupMenuBody.style.fontSize = '10pt';
    popupMenuBody.style.fontFamily = 'Arial';

    popupMenuBody.innerHTML = menuContent;
    popupMenu.show(menuLeft, menuTop, menuWidth, menuHeight, document.body);

    return false;
}

function isNumber(field) {
    var re = /^[0-9-' ']*$/;
    if (!re.test(field.value)) {
        alert("Value must be numbers, letter(s) not allowed!");
        field.value = field.value.replace(/[^0-9-' ']/g, "");
    }
}