[33mcommit 3332d91ac6d30a2a567bf8855b46e99e862e561d[m[33m ([m[1;36mHEAD[m[33m -> [m[1;32mmain[m[33m, [m[1;31morigin/main[m[33m, [m[1;31morigin/HEAD[m[33m)[m
Merge: ee314c7 b444e2c
Author: Anton Dombrovskiy <anton.dombrovskij.cz@gmail.com>
Date:   Fri Mar 28 13:18:15 2025 +0100

    Merge pull request #17 from AntonDambrouski/task3
    
    Add README for Task 3: Asp.Net MVC application setup and requirements

[33mcommit b444e2c7bd9ed65b85699289b43d327b8827d0a0[m[33m ([m[1;31morigin/task3[m[33m)[m
Author: Anton Dambrouski <Anton.Dambrouski@ventionteams.com>
Date:   Fri Mar 28 13:17:17 2025 +0100

    Add README for Task 3: Asp.Net MVC application setup and requirements

[33mcommit ee314c7757c3c462b132c79b2b06024103a2e012[m
Merge: 5c96655 751a413
Author: Anton Dombrovskiy <anton.dombrovskij.cz@gmail.com>
Date:   Thu Mar 27 19:24:07 2025 +0100

    Merge pull request #16 from AntonDambrouski/movie-manager
    
    Add movie manager web app

[33mcommit 751a41340d33fe5d7b65b8f9f1525d17543147d0[m[33m ([m[1;31morigin/movie-manager[m[33m)[m
Author: Anton Dambrouski <Anton.Dambrouski@ventionteams.com>
Date:   Thu Mar 27 19:22:31 2025 +0100

    Add movie manager web app

[33mcommit 5c96655a054282611b42ef7c0813ce15d1f0124d[m
Merge: cd28d3b 3709a69
Author: Anton Dombrovskiy <anton.dombrovskij.cz@gmail.com>
Date:   Wed Mar 26 11:55:10 2025 +0100

    Merge pull request #14 from AntonDambrouski/update-lesson2
    
    Add "Stuff" area and enhance product management features

[33mcommit 3709a69e2cb53ffca0c2c29bc477dec2feeef898[m[33m ([m[1;31morigin/update-lesson2[m[33m)[m
Author: Anton Dambrouski <Anton.Dambrouski@ventionteams.com>
Date:   Wed Mar 26 11:54:05 2025 +0100

    Add "Stuff" area and enhance product management features
    
    - Updated `HomeController` and `ProductsController` to include `[Area("Stuff")]` attribute and restructured namespaces.
    - Enhanced `Product` model with validation annotations.
    - Modified `FirstMvcApp.csproj` to include a new controllers folder and added necessary package reference for scaffolding.
    - Set default launch URL to "stuff" in `launchSettings.json`.
    - Updated routing in `Program.cs` for better organization of the "Stuff" area.
    - Restructured views to include model binding and validation summaries for improved user experience.
    - Updated navigation links in `_Layout.cshtml` to reflect the new area structure.
    - Created new interfaces for product management services, promoting better separation of concerns.
    - Added `ProductsReadOnlyService` for read-only product operations (implementation pending).
    - Introduced CSS for `Index.cshtml` to enhance visual presentation.
    - Created `ViewImports.cshtml` and `ViewStart.cshtml` for common directives and layout setup.
    - Overall improvements enhance the structure, organization, and functionality of the ASP.NET Core MVC application.

[33mcommit cd28d3b3985a3412376f1183a67033bc1efd6edd[m[33m ([m[1;31morigin/rnosevich_Task2[m[33m)[m
Merge: f9a7e3f da4f8c1
Author: Anton Dombrovskiy <anton.dombrovskij.cz@gmail.com>
Date:   Fri Mar 21 10:41:09 2025 +0100

    Merge pull request #11 from AntonDambrouski/add-lesson2
    
    Add mvc app

[33mcommit da4f8c1b9c7d90ba321ee23f06cb0c31c0b510ad[m[33m ([m[1;31morigin/add-lesson2[m[33m)[m
Author: Anton Dambrouski <Anton.Dambrouski@ventionteams.com>
Date:   Fri Mar 21 10:40:30 2025 +0100

    Add mvc app

[33mcommit f9a7e3f0d563b559c3085093a8d0c90aed6fb99d[m
Merge: c14e4a5 d187037
Author: Anton Dombrovskiy <anton.dombrovskij.cz@gmail.com>
Date:   Wed Mar 19 14:58:07 2025 +0100

    Merge pull request #8 from AntonDambrouski/AntonDambrouski-patch-1
    
    Update README.md

[33mcommit d187037f351d123fd5eef4726c866ad0994a3859[m[33m ([m[1;31morigin/AntonDambrouski-patch-1[m[33m)[m
Author: Anton Dombrovskiy <anton.dombrovskij.cz@gmail.com>
Date:   Wed Mar 19 14:57:12 2025 +0100

    Update README.md

[33mcommit c14e4a5908b9d7e9eedab4a5d02e4816c6e415ad[m
Merge: cc62e63 ded23f1
Author: Anton Dombrovskiy <anton.dombrovskij.cz@gmail.com>
Date:   Wed Mar 19 14:56:32 2025 +0100

    Merge pull request #7 from AntonDambrouski/add-task2
    
    Add task 2

[33mcommit ded23f1cb748f426f661b731a8bb8a164b156200[m[33m ([m[1;31morigin/add-task2[m[33m)[m
Author: Anton Dambrouski <Anton.Dambrouski@ventionteams.com>
Date:   Wed Mar 19 14:52:52 2025 +0100

    Add task 2

[33mcommit cc62e63a6a2d0655a5d23648e76eac3468970fec[m
Merge: 5208b00 3cf5588
Author: Anton Dombrovskiy <anton.dombrovskij.cz@gmail.com>
Date:   Wed Mar 19 10:15:22 2025 +0100

    Merge pull request #6 from AntonDambrouski/add-lesson
    
    Add design patterns and SOLID principles implementation

[33mcommit 3cf5588c76c53f1732c940576e80195ae8d6b871[m[33m ([m[1;31morigin/add-lesson[m[33m)[m
Author: Anton Dambrouski <Anton.Dambrouski@ventionteams.com>
Date:   Wed Mar 19 10:09:23 2025 +0100

    Add design patterns and SOLID principles implementation
    
    Created project and solution files. Implemented various design patterns including Adapter, Builder, Decorator, Factory, Observer, and Strategy. Demonstrated SOLID principles with examples in respective files, ensuring better code organization and adherence to best practices. Updated `Program.cs` to execute the StrategyDemo.

[33mcommit 5208b0003cf01d40fecda83ec960ef366e8f7eca[m
Author: Anton Dambrouski <Anton.Dambrouski@ventionteams.com>
Date:   Thu Mar 13 19:58:21 2025 +0100

    add space

[33mcommit 277b3286796f785e89d90ac0de346c69ec7ca3d5[m
Author: Anton Dambrouski <Anton.Dambrouski@ventionteams.com>
Date:   Thu Mar 13 19:53:45 2025 +0100

    Update readme

[33mcommit bf5ffb3ea3fd809db7b453a464b52492fda025bc[m
Author: Anton Dambrouski <Anton.Dambrouski@ventionteams.com>
Date:   Thu Mar 13 19:51:15 2025 +0100

    Add Task 1

[33mcommit fdc32594e9c3a945048b60a881f466fe1c927bb7[m
Author: Anton Dambrouski <Anton.Dambrouski@ventionteams.com>
Date:   Thu Mar 13 19:16:39 2025 +0100

    Init
