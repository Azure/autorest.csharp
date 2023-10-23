// <auto-generated/>

#nullable disable

namespace OpenAI.Models
{
    /// <summary> The CreateCategories. </summary>
    public partial class CreateCategories
    {
        /// <summary> Initializes a new instance of CreateCategories. </summary>
        /// <param name="hate">
        /// Content that expresses, incites, or promotes hate based on race, gender, ethnicity,
        /// religion, nationality, sexual orientation, disability status, or caste. Hateful content
        /// aimed at non-protected groups (e.g., chess players) is harrassment.
        /// </param>
        /// <param name="hateThreatening">
        /// Hateful content that also includes violence or serious harm towards the targeted group
        /// based on race, gender, ethnicity, religion, nationality, sexual orientation, disability
        /// status, or caste.
        /// </param>
        /// <param name="harassment"> Content that expresses, incites, or promotes harassing language towards any target. </param>
        /// <param name="harassmentThreatening"> Harassment content that also includes violence or serious harm towards any target. </param>
        /// <param name="selfHarm">
        /// Content that promotes, encourages, or depicts acts of self-harm, such as suicide, cutting,
        /// and eating disorders.
        /// </param>
        /// <param name="selfHarmIntent">
        /// Content where the speaker expresses that they are engaging or intend to engage in acts of
        /// self-harm, such as suicide, cutting, and eating disorders.
        /// </param>
        /// <param name="selfHarmInstructive">
        /// Content that encourages performing acts of self-harm, such as suicide, cutting, and eating
        /// disorders, or that gives instructions or advice on how to commit such acts.
        /// </param>
        /// <param name="sexual">
        /// Content meant to arouse sexual excitement, such as the description of sexual activity, or
        /// that promotes sexual services (excluding sex education and wellness).
        /// </param>
        /// <param name="sexualMinors"> Sexual content that includes an individual who is under 18 years old. </param>
        /// <param name="violence"> Content that depicts death, violence, or physical injury. </param>
        /// <param name="violenceGraphic"> Content that depicts death, violence, or physical injury in graphic detail. </param>
        internal CreateCategories(bool hate, bool hateThreatening, bool harassment, bool harassmentThreatening, bool selfHarm, bool selfHarmIntent, bool selfHarmInstructive, bool sexual, bool sexualMinors, bool violence, bool violenceGraphic)
        {
            Hate = hate;
            HateThreatening = hateThreatening;
            Harassment = harassment;
            HarassmentThreatening = harassmentThreatening;
            SelfHarm = selfHarm;
            SelfHarmIntent = selfHarmIntent;
            SelfHarmInstructive = selfHarmInstructive;
            Sexual = sexual;
            SexualMinors = sexualMinors;
            Violence = violence;
            ViolenceGraphic = violenceGraphic;
        }

        /// <summary>
        /// Content that expresses, incites, or promotes hate based on race, gender, ethnicity,
        /// religion, nationality, sexual orientation, disability status, or caste. Hateful content
        /// aimed at non-protected groups (e.g., chess players) is harrassment.
        /// </summary>
        public bool Hate { get; }
        /// <summary>
        /// Hateful content that also includes violence or serious harm towards the targeted group
        /// based on race, gender, ethnicity, religion, nationality, sexual orientation, disability
        /// status, or caste.
        /// </summary>
        public bool HateThreatening { get; }
        /// <summary> Content that expresses, incites, or promotes harassing language towards any target. </summary>
        public bool Harassment { get; }
        /// <summary> Harassment content that also includes violence or serious harm towards any target. </summary>
        public bool HarassmentThreatening { get; }
        /// <summary>
        /// Content that promotes, encourages, or depicts acts of self-harm, such as suicide, cutting,
        /// and eating disorders.
        /// </summary>
        public bool SelfHarm { get; }
        /// <summary>
        /// Content where the speaker expresses that they are engaging or intend to engage in acts of
        /// self-harm, such as suicide, cutting, and eating disorders.
        /// </summary>
        public bool SelfHarmIntent { get; }
        /// <summary>
        /// Content that encourages performing acts of self-harm, such as suicide, cutting, and eating
        /// disorders, or that gives instructions or advice on how to commit such acts.
        /// </summary>
        public bool SelfHarmInstructive { get; }
        /// <summary>
        /// Content meant to arouse sexual excitement, such as the description of sexual activity, or
        /// that promotes sexual services (excluding sex education and wellness).
        /// </summary>
        public bool Sexual { get; }
        /// <summary> Sexual content that includes an individual who is under 18 years old. </summary>
        public bool SexualMinors { get; }
        /// <summary> Content that depicts death, violence, or physical injury. </summary>
        public bool Violence { get; }
        /// <summary> Content that depicts death, violence, or physical injury in graphic detail. </summary>
        public bool ViolenceGraphic { get; }
    }
}
