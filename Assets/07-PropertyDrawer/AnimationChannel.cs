public enum
AnimationChannel {
    Layer_0 = 1,
    Layer_1 = 2,
    Layer_2 = 4,
    Layer_3 = 8,
    Layer_4 = 16,
    Layer_5 = 32,
    Layer_6 = 64,
    Layer_7 = 128,
    Layer_8 = 256,
    Layer_9 = 512,
}

public static class AnimationChannelCross {
    public static bool Cross(AnimationChannel a, AnimationChannel b) {
        return (a & b) != 0;
    }
}