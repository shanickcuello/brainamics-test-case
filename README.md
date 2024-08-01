# brainamics-test-case
##Testcase for Senior Unity Developer at Brainamics

Fixing the score and making a coin spawn every time one is collected were the easy parts. Then, I had some fun adding a couple of packages and preparing the project for scalability, indulging in a bit of over-engineering. The fact that the technical test leaves room for "improving anything you want" can lead to endlessly enhancing the project, haha. I believe I left it in a scalable and much-improved state compared to how I received it.

Some notes:
- I used [Extenject](https://github.com/Mathijs-Bakker/Extenject), but you could also use a singleton to handle dependencies and create a service locator that returns the necessary components.

- I chose [DoTween](https://dotween.demigiant.com/) because it prepares the project for future animations and is very programmer-friendly, but you can achieve the same effect with transform.Rotate. I just wanted to add some magic and scalability to the project.

- I used [Pooling](https://github.com/shanickcuello/SpaceShooterPatternsDesing/blob/main/Assets/Utils/Factory/ObjectPool.cs) from an old project I did

- Regarding code structure, I'm not a fan of grouping by types:
  - Scripts
  - Prefabs
  - ScriptableObjects

I prefer grouping by feature. For example:
- Coin:
  - Scripts
  - Prefabs

I think it’s easier to manage dependencies and keep everything together when working with assemblies, TDD, or unit tests. But that’s just personal preference. I didn’t want to restructure the entire project.
There are still several improvements that can be made. For example, the bounds could be adjusted to fit the screen size, or the coins could start with an initial rotation so they don’t all rotate the same way. There’s always room for infinite improvement. I decided to stop here to deliver the test within a reasonable timeframe.

Cheers! 
