﻿namespace ExtendBuilderDesignPattern
{
    public class ComputerBuilderDirector : ComputerStorageBuilder<ComputerBuilderDirector>
    {
        public static ComputerBuilderDirector NewComputer => new ComputerBuilderDirector();
    }
}
