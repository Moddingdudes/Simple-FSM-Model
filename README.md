# Simple FSM Model

This is a very simple FSM model for Unity AIs.

It is based off of [this article](https://www.toptal.com/unity-unity3d/unity-ai-development-finite-state-machine-tutorial) which used Scriptable Objects.
However, Scriptable Objects seemed like the wrong option since it was required to pass in the State Machine object, causing cyclic dependency.
The decisions and actions should have object information, so they should be components.
