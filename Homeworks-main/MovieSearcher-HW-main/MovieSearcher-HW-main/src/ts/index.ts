import $ from "jquery";

interface omdbapiResponse
{
    Title: string,
    Year: string,
    imdbID: string,
    Type: string,
    Poster: string
}

interface Response{
    Response: string,
    totalResults: string,
    Search: omdbapiResponse[],
}

$(function f()
{
    const apiKey: string = "35f7f5d0";

    let $submitForm = $("#search-form");
    let $titleFilm = $("#textbox");
    let $typeOfFilm = $("#select");
    let $filmsarea = $("#filmsdiv");
    let $pages = $("#pagebox");
    let $buttonLeft = $("#buttonLeft");
    let $buttonRight = $("#buttonRight");
    let $pagination = $("#pagination");

    $submitForm.on("submit", (e) => {
        e.preventDefault();

        $pagination.css("display", "block");

        try{
            let pages: number = $pages.val() as number;

            $filmsarea.empty();

            $.ajax({
                url: `http://www.omdbapi.com/?i=tt3896198&apikey=${apiKey}&s=${$titleFilm.val()}&type=${$typeOfFilm.val()}&page=${pages}`,
                error: (e) => {
                    console.log("FAILED");
                },
                success: (data) => {
                    if (($titleFilm.val() as string).length < 1)
                    {
                        $pagination.css("display", "none");
                        return;
                    }
                
                    let response: Response = data;

                    let pagesCount = parseInt(response.totalResults) / 10;

                    for (let i = 0; i < 10; i++)
                    {
                        $filmsarea.append(`<div style='float: left; padding: 15px; width: 150px'><img class="image" src="${JSON.stringify(response.Search[i].Poster).slice(1,-1)}" alt="no poster"> <div class="type">${JSON.stringify(response.Search[i].Type).slice(1,-1)}</div> 
                        <div class="title">${JSON.stringify(response.Search[i].Title).slice(1,-1)}</div>
                        <div class="year">${JSON.stringify(response.Search[i].Year).slice(1,-1)}</div></div>`);
                        
                        $(".image").css("width", "130px").css("height", "150px");
                        $(".type").css("margin-left", "10px");
                        $(".title").css("margin-left", "10px");
                        $(".year").css("margin-left", "10px");
                    }

                    console.log(data);

                    $buttonRight.on("click", (e) => {
                        if(pages <= pagesCount)
                        {
                            $pages.val(++pages);
                            show(apiKey, $titleFilm.val(), $typeOfFilm.val(), ($pages.val() as number), $filmsarea);
                        }
                        else{
                            alert(`Pages can not be more than ${pagesCount + 1}!`);
                        }
                    });

                    $buttonLeft.on("click", (e) => {
                        if (pages > 0)
                        {
                            $pages.val(--pages);
                            show(apiKey, $titleFilm.val(), $typeOfFilm.val(), ($pages.val() as number), $filmsarea);
                        }
                        else{
                            alert("Pages can not be less than 1!");
                        }
                    });

                    $(document).on('keypress', function(e) {
                        if(e.which === 13 && ($pages.val() as number) > 0 && ($pages.val() as number) <= pagesCount) 
                        {
                            show(apiKey, $titleFilm.val(), $typeOfFilm.val(), ($pages.val() as number), $filmsarea);
                        }
                    });
                },
                complete: (e) => {
                    console.log("COMPLETE");
                },
                method: "GET",
                crossDomain: true,
                });                  
        }
        catch(error)
        {
            console.log(error);
        }
    });
});

function show(apiKey: string, titleFilm: any, typeOfFilm: any, pages: number, filmsArea: any)
{
    filmsArea.empty();

    $.ajax({
        url: `http://www.omdbapi.com/?i=tt3896198&apikey=${apiKey}&s=${titleFilm}&type=${typeOfFilm}&page=${pages}`,
        error: (e) => {
            console.log("FAILED");
        },
        success: (data) => {
            if (titleFilm.length < 1)
            {
                return;
            }
        
            let response: Response = data;

            for (let i = 0; i < 10; i++)
            {
                filmsArea.append(`<div style='float: left; padding: 15px; width: 150px'><img class="image" src="${JSON.stringify(response.Search[i].Poster).slice(1,-1)}" alt="no poster"> <div class="type">${JSON.stringify(response.Search[i].Type).slice(1,-1)}</div> 
                <div class="title">${JSON.stringify(response.Search[i].Title).slice(1,-1)}</div>
                <div class="year">${JSON.stringify(response.Search[i].Year).slice(1,-1)}</div></div>`);
                
                $(".image").css("width", "130px").css("height", "150px");
                $(".type").css("margin-left", "10px");
                $(".title").css("margin-left", "10px");
                $(".year").css("margin-left", "10px");
            }
        },
        complete: (e) => {
            console.log("COMPLETE");
        },
        method: "GET",
        crossDomain: true,
        });           
}