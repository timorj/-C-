using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarLibrary
{
    public enum EngineState
    {
        engineAlive, engineDead
    }
    public enum MusicMedia
    {
        musicCD,
        musicTape,
        musicRadio,
        musicMP3
    }
    public abstract class Car
    {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        protected EngineState egnstate = EngineState.engineAlive;

        public EngineState EngineState { get => EngineState; }

        public abstract void TurboBoost();

        public Car()
        {
            MessageBox.Show("CarLibrary version 2.0!");
        }
        public Car(string name, int maxSp, int currSp)
        {
            MessageBox.Show("CarLibrary version 2.0!");

            PetName = name;
            MaxSpeed = maxSp;
            CurrentSpeed = currSp;
        }
        public void TurnOnRadio(bool musicOn, MusicMedia media)
        {
            if (musicOn)
            {
                MessageBox.Show(string.Format("Jamming {0}", media));
            }
            else
            {
                MessageBox.Show("Quiet time...");

            }
        }
    }
}
