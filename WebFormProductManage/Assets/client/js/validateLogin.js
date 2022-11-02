
var getInput = document.querySelector('#txt_userName');
var getInputPass = document.querySelector('#txt_userPassWord')
var getSpan1 = getInput.parentElement.querySelector('.errorMessage__1')
var getSpan2 = getInputPass.parentElement.querySelector('.errorMessage__2')
var getBtnLogin = document.querySelector('.btn__Login')
var formLogin = document.querySelector('#form__login')


console.log(formLogin)

function handleEventOnBlur() {

    console.log(getInput)
    console.log(getSpan1)
    getInput.onblur = function () {
        if (!this.value) {
            this.parentElement.classList.add('invalid');
            getSpan1.innerText = "Vui lòng nhập trường này!"
        } else {
            this.parentElement.classList.remove('invalid');
            getSpan1.innerText = ""
        }
    }
    getInputPass.onblur = function () {
        if (!this.value) {
            this.parentElement.classList.add('invalid');
            getSpan2.innerText = "Vui lòng nhập trường này!"
        } else {
            this.parentElement.classList.remove('invalid');
            getSpan2.innerText = ""
        }
    }


}

function handleEventOnInput() {
    getInput.oninput = function () {
        this.parentElement.classList.remove('invalid');
        getSpan1.innerText = ""
    }

    getInputPass.oninput = function () {
        this.parentElement.classList.remove('invalid');
        getSpan2.innerText = ""
    }
}


function handleButton() {

    getBtnLogin.onclick = function () {
        if (!getInput.value) {
            getInput.parentElement.classList.add('invalid');
            getSpan1.innerText = "Vui lòng nhập trường này!"

        }
        if (!getInputPass.value) {
            getInputPass.parentElement.classList.add('invalid');
            getSpan2.innerText = "Vui lòng nhập trường này!"
        }
    }
}

function handleSubmitForm() {
    formLogin.onsubmit = function (e) {
        if (!getInput.value && !getInputPass.value) {
            e.preventDefault();
        }
    }
}

function start() {
    handleEventOnBlur();
    handleEventOnInput();
    handleButton();
    handleSubmitForm();
}

start();
