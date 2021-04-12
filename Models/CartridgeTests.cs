using System;
using System.Collections.Generic;
using Models;
using Action = Models.Action;

namespace CartridgeServer.Test
{
    public class CartridgeTests
    {
        public readonly Cartridge TestCartridge;

        public CartridgeTests()
        {
            TestCartridge = new Cartridge()
            {
                Name = "test game",
                Graph = new List<Graph>()
                {
                    new Graph()
                    {
                        Source = "Entrance",
                        Target = "1stRoom",
                        Direction = Direction.North,
                        Distance = 1,
                    },
                    new Graph()
                    {
                        Source = "1stRoom",
                        Target = "BigRoom",
                        Distance = 1,
                        Direction = Direction.North
                    }

                },
                WinCondition = new WinCondition()
                {
                    Condition = new Condition()
                    {
                        Left = "hp",
                        Right = "0",
                        Symbol = "<=",
                        Type = "comparison"
                    },
                    Source = "npc"
                },
                LoseCondition = new LoseCondition()
                {
                    Condition = new Condition()
                    {
                        Left = "hp",
                        Right = "0",
                        Symbol = "<=",
                        Type = "comparison"
                    },
                    Source = "player"
                },
                Locations = new List<Location>()
                {
                    new Location()
                    {
                        Name = "Entrance",
                        Description = new Description()
                        {
                            DefaultDescription = "You're at the entrance of the dungeon. There are two lit torches on each wall (one on your right and one on your left). You see only one path: ahead."
                        },
                        Items = new List<Item>()
                        {
                            new Item()
                            {
                                Id = "littorch1",
                                Name = "Lit torch on the right",
                                Details = "A lit torch",
                                Triggers = new List<Trigger>()
                                {
                                    new Trigger()
                                    {
                                        Action = Action.pickup,
                                        Effect = new Effect()
                                        {
                                            AddStatus = "has light",
                                            Target = "game"
                                        }
                                    },
                                    new Trigger()
                                    {
                                        Action = Action.drop,
                                        Effect = new Effect()
                                        {
                                            RemoveStatus = "has light",
                                            Target = "game"
                                        }
                                    }
                                },
                                Destination = ItemDestination.hand
                            },
                            new Item()
                            {
                                Id = "littorch2",
                                Name = "lt torch on the left",
                                Details = "A lit torch",
                                Destination = ItemDestination.hand,
                                Triggers = new List<Trigger>()
                                {
                                    new Trigger()
                                    {
                                        Action = Action.pickup,
                                        Effect = new Effect()
                                        {
                                            AddStatus = "has light",
                                            Target = "game"
                                        }
                                    },
                                    new Trigger()
                                    {
                                        Action = Action.drop,
                                        Effect = new Effect()
                                        {
                                            RemoveStatus = "has light",
                                            Target = "Game"
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Location()
                    {
                        Name = "1stRoom",
                        Description = new Description()
                        {
                            DefaultDescription = "You're in a very dark room. There are no windows and no source of light, other than the one at the entrance. You get the feeling you're not alone here.",
                            Conditionals = new List<Conditional>()
                            {
                                new Conditional()
                                {
                                    Name = "has light",
                                    Description = "The room you find yourself in appears to be empty, aside from a single chair in the right corner. There appears to be only one way out: deeper into the dungeon."
                                }
                            }
                        },
                        Items = new List<Item>()
                        {
                            new Item()
                            {
                                Id = "chair",
                                Name = "Wooden chair",
                                Details = "It's a wooden chair, nothing fancy about it. It appears to have been sitting here, untouched, for a while now.",
                                Subitems = new List<Subitem>()
                                {
                                    new Subitem()
                                    {
                                        Id = "woodenleg",
                                        Name = "Wooden Leg",
                                        Destination = ItemDestination.inventory,
                                        Statses = new List<Stats>()
                                        {
                                            new Stats()
                                            {
                                                Name = "Damage",
                                                Value = 2
                                            }
                                        },
                                        Triggers = new List<Trigger>()
                                        {
                                            new Trigger()
                                            {
                                                Action = Action.breakitem,
                                                Target = "chair"
                                            },
                                            new Trigger()
                                            {
                                                Action = Action.throwitem,
                                                Target = "chair"
                                            }
                                        }
                                    }
                                }
                                
                            }
                        }

                    },
                    new Location()
                    {
                        Name = "bigRoom",
                        Description = new Description()
                        {
                            DefaultDescription = "You've reached the big room. On every wall are torches lighting every corner. The walls are painted white, and the ceiling is tall and filled with painted white stars on a black background. There is a gateway on either side and a big, wooden double door in front of you.",
                        },
                        Exits = new List<Exit>()
                        {
                            new Exit()
                            {
                                Id = "bossDoor",
                                Name = "Big double door",
                                Status = "locked",
                                Details = "A big, wooden double door. It seems like something big usually comes through here.",
                                Direction = Direction.North
                            }
                        }
                    },
                    new Location()
                    {
                        Name = "leftwing",
                        Description = new Description()
                        {
                            DefaultDescription = "Another dark room. It doesn't look like it's that big, but you can't really tell what's inside. You do, however, smell rotten meat somewhere inside.",
                            Conditionals = new List<Conditional>()
                            {
                                new Conditional()
                                {
                                    Name = "has light",
                                    Description = "You appear to have found the kitchen. There are tables full of meat everywhere, and a big knife sticking out of what appears to be the head of a cow. There is also a gun  laying down on a corner of the room."
                                }
                            }
                        },
                        Items = new List<Item>()
                        {
                            new Item()
                            {
                                Id = "bigknife",
                                Name ="Big knife",
                                Destination = ItemDestination.inventory,
                                Type =ItemType.blade,
                            },
                            new Item()
                            {
                                Id="gun",
                                Name="Gun",
                                Destination =  ItemDestination.inventory,
                                Type = ItemType.gun
                            }
                        }
                    },
                    new Location()
                    {
                        Name = "rightWing",
                        Description = new Description()
                        {
                            DefaultDescription = "This appear to be some sort of office. There is a wooden desk in the middle, torches lighting every wall, and a single Golden key resting on top of the desk."
                        },
                        Items =new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Golden Key",
                                Details = "A small golden key. What use could you have for it?",
                                Destination = ItemDestination.inventory,
                                Triggers = new List<Trigger>()
                                {
                                    new Trigger()
                                    {
                                        Action = Action.use,
                                        Target = "bigRoom",
                                        SubTarget = new SubTarget()
                                        {
                                            Location = "bigRoom",
                                            Exit = "Big double door"
                                        },
                                        Effect = new Effect()
                                        {
                                            StatusUpdate = "unlocked",
                                            Target = "bigRoom",
                                            SubTarget = new SubTarget()
                                            {
                                                Location = "bigRoom",
                                                Exit = "Big double door"
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    },
                    new Location()
                    {
                        Name = "BossRoom",
                        Description = new Description()
                        {
                            DefaultDescription = "You appear to have reached the end of the dungeon. There are no exits other than the one you just came in through. The only other thing that bothers you is the Hulking Ogre looking like it's going to kill you, standing about 10 feet from you."
                        },
                        Npcs = new List<Npc>()
                        {
                            new Npc()
                            {
                                Id = "finalboss",
                                Name = "Hulking Ogre",
                                Details = "A huge, green, muscular giant with a single eye in the middle of his forehead. It doesn't just look bad, it also smells like hell.",
                                Stats = new List<Stats>()
                                {
                                    new Stats()
                                    {
                                        Name = "blade",
                                        Value = 3
                                    }
                                }
                            }
                        }
                        
                    }
                }
            };
        }
    }
}
