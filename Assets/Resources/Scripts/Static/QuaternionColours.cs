using UnityEngine;

public static class QuaternionColours {
    public static readonly Color positiveWhiteColour = hexToColour("ffffff");
    public static readonly Color positiveRedColour = hexToColour("e50c0c");
    public static readonly Color positiveYellowColour = hexToColour("f8ff00");
    public static readonly Color positiveGreenColour = hexToColour("00ff0d");
    public static readonly Color negativeWhiteColour = hexToColour("d1d1d1");
    public static readonly Color negativeRedColour = hexToColour("ebb5dc");
    public static readonly Color negativeYellowColour = hexToColour("ffe491");
    public static readonly Color negativeGreenColour = hexToColour("adfff3");

    public static Color quaternionToColour(Quaternion quaternion) {
        if (quaternion.sign == Sign.POSITIVE) {
            if (quaternion.dimension == Dimension.WHITE) return positiveWhiteColour;
            else if (quaternion.dimension == Dimension.RED) return positiveRedColour;
            else if (quaternion.dimension == Dimension.YELLOW) return positiveYellowColour;
            else return positiveGreenColour;
        }
        else {
            if (quaternion.dimension == Dimension.WHITE) return negativeWhiteColour;
            else if (quaternion.dimension == Dimension.RED) return negativeRedColour;
            else if (quaternion.dimension == Dimension.YELLOW) return negativeYellowColour;
            else return negativeGreenColour;
        }
    }



    private static Color hexToColour(string hex) {
        string redComponent = hex.Substring(0, 2);
        string greenComponent = hex.Substring(2, 2);
        string blueComponent = hex.Substring(4, 2);
        Color colour = new Color(
            hexToDecimal(redComponent) / 255f,
            hexToDecimal(greenComponent) / 255f,
            hexToDecimal(blueComponent) / 255f
        );
        return colour;
    }
    private static float hexToDecimal(string hex) {
        char digit1 = hex[0];
        char digit2 = hex[1];
        return 16 * hexDigitToDecimal(digit1) + hexDigitToDecimal(digit2);
    }
    private static float hexDigitToDecimal(char digit) {        
        float x = 0;
        switch (digit) {
            case '0':
                x = 0;
                break;
            case '1':
                x = 1;
                break;
            case '2':
                x = 2;
                break;
            case '3':
                x = 3;
                break;
            case '4':
                x = 4;
                break;
            case '5':
                x = 5;
                break;
            case '6':
                x = 6;
                break;
            case '7':
                x = 7;
                break;
            case '8':
                x = 8;
                break;
            case '9':
                x = 9;
                break;
            case 'a':
                x = 10;
                break;
            case 'b':
                x = 11;
                break;
            case 'c':
                x = 12;
                break;
            case 'd':
                x = 13;
                break;
            case 'e':
                x = 14;
                break;
            case 'f':
                x = 15;
                break;
        }
        return x;
    }
}
