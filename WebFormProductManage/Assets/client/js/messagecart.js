var getBtnInsert = document.querySelector('.btn__message')
var getBlockMes = document.querySelector('.buy__message')
var getIconClose = document.querySelector('.mes__close')
console.log(getBtnInsert)
console.log(getBlockMes)

function handleMessage() {
    getBtnInsert.onclick = function () {
        getBlockMes.style.display = "block";
    }

    getIconClose.onclick = function () {
        getBlockMes.style.display = "none";
    }
}

handleMessage();