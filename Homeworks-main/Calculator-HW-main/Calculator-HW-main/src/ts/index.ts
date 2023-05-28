import $ from "jquery";
import {CalcFunctions} from "../../Services/CalcService";

$(function f()
{
    let $mainscreen = $("#mainscreen");
    let $screen = $("#screen");
    let $button0 = $("#button0");
    let $button1 = $("#button1");
    let $button2 = $("#button2");
    let $button3 = $("#button3");
    let $button4 = $("#button4");
    let $button5 = $("#button5");
    let $button6 = $("#button6");
    let $button7 = $("#button7");
    let $button8 = $("#button8");
    let $button9 = $("#button9");
    let $buttonClear = $(".clear");
    let $operatorDivision = $(".operatorDivision");
    let $operatorMultiply = $(".operatorMultiply");
    let $operatorDelete = $(".operatorDelete");
    let $operatorSubtract = $(".operatorSubtract");
    let $operatorPlus = $(".operatorPlus");
    let $buttonEval = $(".eval");
    let $buttonRemainder = $("#buttonRemainder");
    let $buttonPoint = $("#buttonPoint");

    $mainscreen.attr('disabled', 'disabled');
    $screen.attr('disabled', 'disabled');

    $buttonEval.on("click", (e) => {
        // let answer = calculate(($mainscreen.val() as string)[0], ($mainscreen.val() as string)[1], $mainscreen.val() as string[2]);
        // $screen.val(answer);
        // 
        let answer = eval($mainscreen.val() as string);
        $screen.val(answer);
    });

    $buttonClear.on("click", (e) => {
        CalcFunctions.clearScreen($mainscreen, $screen);
    });

    $operatorPlus.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '+');
    });

    $operatorSubtract.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '-');
    });

    $operatorDivision.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '/');
    });

    $operatorMultiply.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '*');
    });

    $buttonRemainder.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '%');
    });

    $operatorDelete.on("click", (e) => {
        deleteLastElem();
    });

    $buttonPoint.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '.');
    });

    $button0.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '0');
    });

    $button1.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '1');
    });

    $button2.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '2');
    });

    $button3.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '3');
    });

    $button4.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '4');
    });

    $button5.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '5');
    });

    $button6.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '6');
    });

    $button7.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '7');
    });


    $button8.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '8');
    });


    $button9.on("click", (e) => {
        $mainscreen.val($mainscreen.val() + '9');
    });

    function deleteLastElem()
    {
        var myScreen = $mainscreen.val() as string;
        $mainscreen.val(myScreen.slice(0,-1));
    }
});


