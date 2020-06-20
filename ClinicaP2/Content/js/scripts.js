
$(document).ready(function () {
    $('.sidebar li:has(ul)').click(function (e) {
        //e.preventDefault();

        if ($(this).hasClass('activado')) {
            $(this).removeClass('activado');
            $(this).children('ul').slideUp();

        } else {
            $('.sidebar li ul').slideUp();
            $('.sidebar li').removeClass('activado');
            $(this).addClass('activado');
            $(this).children('ul').slideDown();
        }
    });
    $('.sidebar li ul li').click(function () {

    });

});

var listaeleme = document.querySelectorAll(".sidebar ul li");  //selecciona las clases sidebar ul li
var hamburger = document.querySelector(".hamburger");
var wrapper = document.querySelector(".wrapper");


listaeleme.forEach((li_item)=>{
	li_item.addEventListener("mouseenter", ()=>{
		if(wrapper.classList.contains("click_collapse")){
            return;
           
        }
      
        else {
           
			//li_item.closest(".wrapper").classList.remove("hover_collapse");
		}
	})
})







hamburger.addEventListener("click", () => {
	hamburger.closest(".wrapper").classList.toggle("click_collapse");
	hamburger.closest(".wrapper").classList.toggle("hover_collapse");
})
