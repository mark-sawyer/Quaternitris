using UnityEngine;

public static class RandomQuaternion {
    public static Quaternion exe() {
        Sign sign = (Sign)Random.Range(0, 2);
        Dimension dimension = (Dimension)Random.Range(0, 4);
        return new Quaternion(sign, dimension);
    }
}
