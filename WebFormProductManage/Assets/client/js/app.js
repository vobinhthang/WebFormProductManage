
var arrImg = ["Assets/client/img/img__slider01.PNG", "Assets/client/img/img__slider02.jpg", "Assets/client/img/img__slider03F.PNG",
    "Assets/client/img/img__slider04.jpg", "Assets/client/img/img__slider05.jpg", "Assets/client/img/img__slider06.jpg"];
const getImg = document.querySelector(".img__show")
var index = 1;

console.log("Quang dep trai")

const handleSlider = function () {
    const getBtnSlider = document.querySelectorAll(".btn__click")

    getBtnSlider[0].onclick = function () {
        getImg.src = arrImg[index];
        index++;

        if (index > arrImg.length - 1) {
            index = 0;
        }

    }

    getBtnSlider[1].onclick = function () {
        getImg.src = arrImg[index];
        index++;

        if (index > arrImg.length - 1) {
            index = 0;
        }

    }
}

const autoSlider = function () {
    getImg.src = arrImg[index];
    index++
    if (index > arrImg.length - 1) {
        index = 0;
    }
}


const autoText = function () {
    var getMarquee = document.querySelector(".icon__bull");
    getMarquee.classList.toggle("icon__bull-color");

    var getProductHot = document.querySelector('.product__hot');
    getProductHot.classList.toggle("icon__bull-color");
}

const addOpacity = function () {
    getImg.classList.add("img__opacity")
}

const removeOpacity = function () {
    getImg.classList.remove("img__opacity")
}

function handleScroll() {
    const getIconUp = document.querySelector('.up__header');
    window.onscroll = function () {
        const getValueSc = window.scrollY;
        console.log(getValueSc)
        if (getValueSc >= 300) {
            getIconUp.style.display = "block";
        } else {
            getIconUp.style.display = "none";
        }
    }
}


function start() {
    handleSlider()
    setInterval(autoSlider, 3000);
    setInterval(autoText, 1000);
    setInterval(addOpacity, 3000);
    setInterval(removeOpacity, 4000);
    handleScroll();
}

start()