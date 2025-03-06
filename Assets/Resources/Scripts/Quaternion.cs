
public struct Quaternion {
    public Sign sign { get; private set; }
    public Dimension dimension { get; private set; }



    public Quaternion(Sign sign, Dimension dimension) {
        this.sign = sign;
        this.dimension = dimension;
    }
    public Quaternion transform(Quaternion rightQuaternion) {
        Sign newSign = Sign.POSITIVE;
        Dimension newDimension = Dimension.WHITE;

        if (dimension == Dimension.WHITE) {
            newDimension = rightQuaternion.dimension;
            newSign = rightQuaternion.sign;
        }
        else if (rightQuaternion.dimension == Dimension.WHITE) {
            newDimension = dimension;
            newSign = rightQuaternion.sign;
        }
        else if (dimension == rightQuaternion.dimension) {
            newDimension = Dimension.WHITE;
            newSign = signSwap(rightQuaternion.sign);
        }
        else {
            Dimension nextDimension = getNextDimension(dimension);
            Dimension previousDimension = getPreviousDimension(dimension);
            if (rightQuaternion.dimension == nextDimension) {
                newDimension = previousDimension;
                newSign = rightQuaternion.sign;
            }
            else {
                newDimension = nextDimension;
                newSign = signSwap(rightQuaternion.sign);
            }
        }

        if (sign == Sign.NEGATIVE) newSign = signSwap(newSign);

        return new Quaternion(newSign, newDimension);
    }



    private Sign signSwap(Sign sign) {
        if (sign == Sign.POSITIVE) return Sign.NEGATIVE;
        return Sign.POSITIVE;
    }
    private Dimension getNextDimension(Dimension dimension) {
        if (dimension == Dimension.RED) return Dimension.YELLOW;
        if (dimension == Dimension.YELLOW) return Dimension.GREEN;
        if (dimension == Dimension.GREEN) return Dimension.RED;

        throw new System.Exception("Red has no next dimension");
    }
    private Dimension getPreviousDimension(Dimension dimension) {
        if (dimension == Dimension.RED) return Dimension.GREEN;
        if (dimension == Dimension.YELLOW) return Dimension.RED;
        if (dimension == Dimension.GREEN) return Dimension.YELLOW;

        throw new System.Exception("Red has no previous dimension");
    }
}
