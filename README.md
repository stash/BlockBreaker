# BlockBreaker

Break-Out/Arkanoid clone in Unity, based on https://www.udemy.com/unitycourse/learn/v4/overview

Play it on the web here: https://stash.github.io/BlockBreaker/ (known issue: the sound effects don't seem to pan properly on the web)

## Improvements over stock tutorial

Wanted to challenge myself in a few different areas instead of sticking to the cut-and-dry tutorial and make something a little bit more polished.

**Graphics:**

1. Custom brick sprite sheet with hand-drawn crack animations, created with Gimp.
1. Rounded-corner paddle "chamfer" instead of the triangle-tip one in the tutorial. Uses a nine-segment sprite so the paddle can be resized.
1. Particle effect "sparks" when the ball hits an indestructable brick (including custom "burst" spark texture created in Gimp).
1. Particle effect "explosion" upon the ball leaving the play area.
1. Inter-level fade-out animation using the built-in Unity Animation components.
1. Font used is from https://www.dafont.com/another-brick.font - "free for personal use"

**Sound:**

1. Composed BGM in [OpenMPT](https://openmpt.org/) (though the "meat" of the song is from looperman: https://www.looperman.com/loops/detail/120273/aqua-synth-130bpm-by-ofekz83-free-130bpm-techno-synth-loop and https://www.looperman.com/loops/detail/121895/arp-synth-130bpm-by-ofekz83-free-130bpm-techno-synth-loop)
1. Custom "AudioLoopWithIntro" class to handle the fact that the song has a non-looping introduction then a looping main part; Unity 2017.3 doesn't provide this functionality out of the box.
1. Added nicer sound effects gathered from other free Unity tutorials (SpaceShooter), [FreeSound](https://freesound.org) or hand-edited in Audacity (e.g. the "crack" clip is an isolated and slowed down version of a wooden board breaking).
1. Instead of using AudioSource.PlayAtPoint(), sound effects are stereo panned based on the horizontal position and are sent to a mixer.
1. The AudioMixers are set up so that the main background music can be "ducked" when a sound effect is playing.

**Gameplay:**

1. Replaced the "random" ball movement tweak with a "move towards center" algorithm. In both cases prevents infinite loops of the ball going up and down forever, plus making the ball gradually faster.

**Other:**

1. Use more prefabs, in general, than in the tutorial.
1. Refactored common routines into a Util class.

# Building

Requirements:

* Unity 2017.3.1f

Then build within Unity. Should work for Win/Mac/Linux target and web.
