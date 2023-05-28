import $ from "jquery";

$(function f()
{
    let $playButton = $("#buttonPlay");
    let $ToStartButton = $("#buttonToStart");
    let $ToEndButton = $("#buttonToEnd");
    let $ToLeftButton = $("#buttonToLeft");
    let $ToRightButton = $("#buttonToRight");
    let $sliderline = $("#slider-line");
    let $slider = $("#slider");
    let $myToggleButton = $("#toggleButton");
    let $photo1 = $("#photo1");
    let $photo2 = $("#photo2");
    let $photo3 = $("#photo3");
    let $photo4 = $("#photo4");
    let $photo5 = $("#photo5");
    let $photo6 = $("#photo6");

    let offset: number = 0;
    let toRight: number = 0;
    let toLeft: number = 0;
    let toggle: boolean = false;
    let toggleButton: boolean = false;
    let counter: number = 0;

    $playButton.on("click", (e) =>
    {
        if (!toggleButton)
        {
            if (!toggle)
            {
                $playButton.attr("value", "pause");

                while(toRight !== 5)
                {        
                    offset += 400;

                    if (offset > 2000)
                    {
                        offset = 0;

                        toRight = -1;
                    }

                    $sliderline.css("left", `${-offset}px`);

                    toRight++;
                }

                setTimeout(function () {$playButton.attr("value", "play");}, 3000);

                toggle = true;
            }       
            
            else if(toggle)
            {
                $playButton.attr("value", "play");

                toggle = false;
            }
        }
        else
        {
            if (!toggle)
            {
                $playButton.attr("value", "a");

                while(toRight !== 5)
                {        
                    offset += 600;

                    if (offset > 3000)
                    {
                        offset = 0;

                        toRight = -1;
                    }

                    $sliderline.css("left", `${-offset}px`);

                    toRight++;
                }
                toggle = true;
            }       
            
            else if(toggle)
            {
                $playButton.attr("value", "play");

                toggle = false;
            }
        }
    });

    $ToEndButton.on("click", (e) =>
    {
        if (!toggleButton)
        {
            offset -= 400 * (5 - toLeft);

            if (offset < 0)
            {
                offset = 2000;
            }
    
            $sliderline.css("left", `${-offset}px`);
            
            toLeft = -1;
        }
        else
        {
            offset -= 600 * (5 - toLeft);

            if (offset < 0)
            {
                offset = 3000;
            }
    
            $sliderline.css("left", `${-offset}px`);
            
            toLeft = -1;
        }
     });
    
    $ToStartButton.on("click", (e) =>
    {        
        if (!toggleButton)
        {
            offset += 400 * (5 - toRight);

            if (offset > 2000)
            {
                offset = 0;
            }
    
            $sliderline.css("left", `${-offset}px`);
            
            toRight = -1;
        }  
        else
        {
            offset += 600 * (5 - toRight);

            if (offset > 3000)
            {
                offset = 0;
            }
    
            $sliderline.css("left", `${-offset}px`);
            
            toRight = -1;
        }         
    });

    $ToLeftButton.on("click", (e) =>
    {
        if (!toggleButton)
        {
            offset -= 400;

            if (offset < 0)
            {
                offset = 2000;
    
                toLeft = -1;
            }
    
            $sliderline.css("left", `${-offset}px`);
    
            toLeft++;
        }
        else
        {
            offset -= 600;

            if (offset < 0)
            {
                offset = 3000;
    
                toLeft = -1;
            }
    
            $sliderline.css("left", `${-offset}px`);
    
            toLeft++;
        }
    });

    $ToRightButton.on("click", (e) =>
    {
        if (!toggleButton)
        {
            offset += 400;

            if (offset > 2000)
            {
                offset = 0;
    
                toRight = -1;
            }
    
            $sliderline.css("left", `${-offset}px`);
    
            toRight++;
        }

        else
        {
            offset += 600;

            if (offset > 3000)
            {
                offset = 0;
    
                toRight = -1;
            }
    
            $sliderline.css("left", `${-offset}px`);
    
            toRight++;
        }
    });

    $myToggleButton.on("click", (e) =>
    {
        if (counter === 0)
        {
            toggleButton = true;
            $slider.css("width", "600px");
            $sliderline.css("width", "3600px");
            $photo1.css("width", "600px");
            $photo2.css("width", "600px");
            $photo3.css("width", "600px");
            $photo4.css("width", "600px");
            $photo5.css("width", "600px");
            $photo6.css("width", "600px");
            counter++;
        }

        else if(counter === 1)
        {
            toggleButton = false;
            $slider.css("width", "400px");
            $sliderline.css("width", "2400px");
            $photo1.css("width", "400px");
            $photo2.css("width", "400px");
            $photo3.css("width", "400px");
            $photo4.css("width", "400px");
            $photo5.css("width", "400px");
            $photo6.css("width", "400px");
            counter--;
        }
    });
});
