export class CalcFunctions
{
    static clearScreen(firstTextBox: JQuery<HTMLElement>, secondTextBox: JQuery<HTMLElement>) {
        firstTextBox.val('');
        secondTextBox.val('');
    }

    static deleteLastElem(firstTextBox: JQuery<HTMLElement>)
    {
        // var myScreen = $mainscreen.val() as string;
        // $mainscreen.val(myScreen.slice(0,-1));
    }
     
    // static display(value: string) {
    //     $screen.val(value);
    // }

    static calculate(leftvalue: string, oper: string, rightvalue: string, ) {
        let finalResult = 0;

        switch (oper)
        {
            case "+": 
            {        
                finalResult = parseFloat(leftvalue) + parseFloat(rightvalue);
                break;
            };

            case "-":
            {
                finalResult = parseFloat(leftvalue) - parseFloat(rightvalue);
                break;
            };

            case "*":
            {
                finalResult = parseFloat(leftvalue) * parseFloat(rightvalue);
                break;
            };

            case "/":
            {
                finalResult = parseFloat(leftvalue) / parseFloat(rightvalue);
                break;
            };

            case "%":
            {
                finalResult = parseFloat(leftvalue) % parseFloat(rightvalue);
                break;
            };
        }

        return finalResult;
    }
}