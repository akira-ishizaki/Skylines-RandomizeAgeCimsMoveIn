using ColossalFramework;
using System;
using UnityEngine;

namespace RandomizeAgeCimsMoveIn
{
    class CustomOutsideConnectionAI : BuildingAI
    {
        public static bool StartConnectionTransfer(ushort buildingID, ref Building data, TransferManager.TransferReason material, TransferManager.TransferOffer offer, int touristFactor0, int touristFactor1, int touristFactor2)
        {
            BuildingManager instance1 = Singleton<BuildingManager>.instance;
            VehicleInfo info = (VehicleInfo)null;
            Citizen.Education education1 = Citizen.Education.Uneducated;
            int num1 = 0;
            bool flag1 = false;
            bool flag2 = false;
            if (material == TransferManager.TransferReason.DummyCar)
            {
                ushort building = offer.Building;
                if ((int)building != 0 && (double)Vector3.SqrMagnitude(instance1.m_buildings.m_buffer[(int)building].m_position - data.m_position) > 40000.0)
                {
                    flag2 = true;
                    switch (Singleton<SimulationManager>.instance.m_randomizer.Int32(34U))
                    {
                        case 0:
                            material = TransferManager.TransferReason.Ore;
                            break;
                        case 1:
                            material = TransferManager.TransferReason.Coal;
                            break;
                        case 2:
                            material = TransferManager.TransferReason.Oil;
                            break;
                        case 3:
                            material = TransferManager.TransferReason.Petrol;
                            break;
                        case 4:
                            material = TransferManager.TransferReason.Grain;
                            break;
                        case 5:
                            material = TransferManager.TransferReason.Food;
                            break;
                        case 6:
                            material = TransferManager.TransferReason.Logs;
                            break;
                        case 7:
                            material = TransferManager.TransferReason.Lumber;
                            break;
                        case 8:
                            material = TransferManager.TransferReason.Goods;
                            break;
                        case 9:
                            material = TransferManager.TransferReason.Goods;
                            break;
                        case 10:
                            material = TransferManager.TransferReason.Single0;
                            break;
                        case 11:
                            material = TransferManager.TransferReason.Single1;
                            break;
                        case 12:
                            material = TransferManager.TransferReason.Single2;
                            break;
                        case 13:
                            material = TransferManager.TransferReason.Single3;
                            break;
                        case 14:
                            material = TransferManager.TransferReason.Single0B;
                            break;
                        case 15:
                            material = TransferManager.TransferReason.Single1B;
                            break;
                        case 16:
                            material = TransferManager.TransferReason.Single2B;
                            break;
                        case 17:
                            material = TransferManager.TransferReason.Single3B;
                            break;
                        case 18:
                            material = TransferManager.TransferReason.Family0;
                            break;
                        case 19:
                            material = TransferManager.TransferReason.Family1;
                            break;
                        case 20:
                            material = TransferManager.TransferReason.Family2;
                            break;
                        case 21:
                            material = TransferManager.TransferReason.Family3;
                            break;
                        case 22:
                            material = TransferManager.TransferReason.Shopping;
                            break;
                        case 23:
                            material = TransferManager.TransferReason.ShoppingB;
                            break;
                        case 24:
                            material = TransferManager.TransferReason.ShoppingC;
                            break;
                        case 25:
                            material = TransferManager.TransferReason.ShoppingD;
                            break;
                        case 26:
                            material = TransferManager.TransferReason.ShoppingE;
                            break;
                        case 27:
                            material = TransferManager.TransferReason.ShoppingF;
                            break;
                        case 28:
                            material = TransferManager.TransferReason.ShoppingG;
                            break;
                        case 29:
                            material = TransferManager.TransferReason.ShoppingH;
                            break;
                        case 30:
                            material = TransferManager.TransferReason.Entertainment;
                            break;
                        case 31:
                            material = TransferManager.TransferReason.EntertainmentB;
                            break;
                        case 32:
                            material = TransferManager.TransferReason.EntertainmentC;
                            break;
                        case 33:
                            material = TransferManager.TransferReason.EntertainmentD;
                            break;
                    }
                }
            }
            switch (material - 13)
            {
                case TransferManager.TransferReason.Garbage:
                    info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialOil, ItemClass.Level.Level2);
                    break;
                case TransferManager.TransferReason.Crime:
                    info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialOre, ItemClass.Level.Level2);
                    break;
                case TransferManager.TransferReason.Sick:
                    info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialForestry, ItemClass.Level.Level2);
                    break;
                case TransferManager.TransferReason.Dead:
                    info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialFarming, ItemClass.Level.Level2);
                    break;
                case TransferManager.TransferReason.Worker0:
                    info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialGeneric, ItemClass.Level.Level1);
                    break;
                case TransferManager.TransferReason.Worker2:
                    info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialOre, ItemClass.Level.Level1);
                    break;
                case TransferManager.TransferReason.Worker3:
                    education1 = Citizen.Education.Uneducated;
                    num1 = Singleton<SimulationManager>.instance.m_randomizer.Int32(2, 5);
                    break;
                case TransferManager.TransferReason.Student1:
                    education1 = Citizen.Education.OneSchool;
                    num1 = Singleton<SimulationManager>.instance.m_randomizer.Int32(2, 5);
                    break;
                case TransferManager.TransferReason.Student2:
                    education1 = Citizen.Education.TwoSchools;
                    num1 = Singleton<SimulationManager>.instance.m_randomizer.Int32(2, 5);
                    break;
                case TransferManager.TransferReason.Student3:
                    education1 = Citizen.Education.ThreeSchools;
                    num1 = Singleton<SimulationManager>.instance.m_randomizer.Int32(2, 5);
                    break;
                case TransferManager.TransferReason.Fire:
                case TransferManager.TransferReason.LeaveCity1:
                    education1 = Citizen.Education.Uneducated;
                    num1 = 1;
                    break;
                case TransferManager.TransferReason.Bus:
                case TransferManager.TransferReason.LeaveCity2:
                    education1 = Citizen.Education.OneSchool;
                    num1 = 1;
                    break;
                case TransferManager.TransferReason.Oil:
                case TransferManager.TransferReason.Entertainment:
                    education1 = Citizen.Education.TwoSchools;
                    num1 = 1;
                    break;
                case TransferManager.TransferReason.Ore:
                case TransferManager.TransferReason.Lumber:
                    education1 = Citizen.Education.ThreeSchools;
                    num1 = 1;
                    break;
                case TransferManager.TransferReason.Goods:
                case TransferManager.TransferReason.Family3:
                case TransferManager.TransferReason.GarbageMove:
                case TransferManager.TransferReason.MetroTrain:
                case TransferManager.TransferReason.PassengerPlane:
                case TransferManager.TransferReason.PassengerShip:
                case TransferManager.TransferReason.DeadMove:
                case TransferManager.TransferReason.DummyCar:
                case TransferManager.TransferReason.DummyTrain:
                case TransferManager.TransferReason.DummyShip:
                case TransferManager.TransferReason.DummyPlane:
                case TransferManager.TransferReason.Single0B:
                    flag1 = true;
                    break;
                case TransferManager.TransferReason.PassengerTrain:
                    info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialOil, ItemClass.Level.Level1);
                    break;
                case TransferManager.TransferReason.Coal:
                    info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialFarming, ItemClass.Level.Level1);
                    break;
                case TransferManager.TransferReason.Single0:
                    info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.Industrial, ItemClass.SubService.IndustrialForestry, ItemClass.Level.Level1);
                    break;
                case TransferManager.TransferReason.Petrol:
                    if ((int)offer.Building != (int)buildingID)
                    {
                        flag2 = true;
                        info = Singleton<SimulationManager>.instance.m_randomizer.Int32(2U) != 0 ? Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportTrain, ItemClass.Level.Level1) : Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportTrain, ItemClass.Level.Level4);
                        break;
                    }
                    break;
                case TransferManager.TransferReason.Food:
                    if ((int)offer.Building != (int)buildingID)
                    {
                        flag2 = true;
                        info = Singleton<SimulationManager>.instance.m_randomizer.Int32(2U) != 0 ? Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportShip, ItemClass.Level.Level1) : Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportShip, ItemClass.Level.Level4);
                        break;
                    }
                    break;
                case TransferManager.TransferReason.LeaveCity0:
                    if ((int)offer.Building != (int)buildingID)
                    {
                        flag2 = true;
                        info = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref Singleton<SimulationManager>.instance.m_randomizer, ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportPlane, ItemClass.Level.Level1);
                        break;
                    }
                    break;
                default:
                    return false;
            }
            if (num1 != 0)
            {
                CitizenManager instance2 = Singleton<CitizenManager>.instance;
                ushort building = offer.Building;
                if ((int)building != 0)
                {
                    uint unitID = 0U;
                    if (!flag2)
                        unitID = instance1.m_buildings.m_buffer[(int)building].GetEmptyCitizenUnit(CitizenUnit.Flags.Home);
                    if ((int)unitID != 0 || flag2)
                    {
                        int family = Singleton<SimulationManager>.instance.m_randomizer.Int32(256U);
                        ushort otherInstance = (ushort)0;
                        Citizen.Gender gender1 = Citizen.Gender.Male;
                        int age2 = Singleton<SimulationManager>.instance.m_randomizer.Int32(0, 60);//追加
                        if (num1 == 2) age2 = Singleton<SimulationManager>.instance.m_randomizer.Int32(-45, 60);//追加
                        for (int index = 0; index < num1; ++index)
                        {
                            uint citizen1 = 0U;
                            int age = Singleton<SimulationManager>.instance.m_randomizer.Int32(index >= 2 ? 0 : 90, index >= 2 ? 15 : 105) + age2;//変更
                            if (num1 == 1) age = Singleton<SimulationManager>.instance.m_randomizer.Int32(Citizen.AGE_LIMIT_TEEN, Citizen.AGE_LIMIT_ADULT - 15);//追加
                            Citizen.Education education2 = index >= 2 ? Citizen.Education.Uneducated : education1;
                            bool citizen2;
                            if (index == 1)
                            {
                                Citizen.Gender gender2 = Singleton<SimulationManager>.instance.m_randomizer.Int32(100U) >= 5 ? (gender1 != Citizen.Gender.Male ? Citizen.Gender.Male : Citizen.Gender.Female) : gender1;
                                citizen2 = instance2.CreateCitizen(out citizen1, age, family, ref Singleton<SimulationManager>.instance.m_randomizer, gender2);
                            }
                            else
                                citizen2 = instance2.CreateCitizen(out citizen1, age, family, ref Singleton<SimulationManager>.instance.m_randomizer);
                            if (citizen2)
                            {
                                if (index == 0)
                                    gender1 = Citizen.GetGender(citizen1);
                                if (education2 >= Citizen.Education.OneSchool)
                                    instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen1)].Education1 = true;
                                if (education2 >= Citizen.Education.TwoSchools)
                                {
                                    instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen1)].Education1 = true;
                                    instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen1)].Education2 = true;
                                }
                                if (education2 >= Citizen.Education.ThreeSchools)
                                {
                                    instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen1)].Education1 = true;
                                    instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen1)].Education2 = true;
                                    instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen1)].Education3 = true;
                                }
                                if (flag2)
                                    instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen1)].m_flags |= Citizen.Flags.DummyTraffic;
                                else
                                    instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen1)].SetHome(citizen1, (ushort)0, unitID);
                                instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen1)].m_flags |= Citizen.Flags.MovingIn;
                                CitizenInfo citizenInfo = instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen1)].GetCitizenInfo(citizen1);
                                ushort instance3;
                                if (citizenInfo != null && instance2.CreateCitizenInstance(out instance3, ref Singleton<SimulationManager>.instance.m_randomizer, citizenInfo, citizen1))
                                {
                                    if ((int)otherInstance == 0)
                                    {
                                        citizenInfo.m_citizenAI.SetSource(instance3, ref instance2.m_instances.m_buffer[(int)instance3], buildingID);
                                        citizenInfo.m_citizenAI.SetTarget(instance3, ref instance2.m_instances.m_buffer[(int)instance3], building);
                                        otherInstance = instance3;
                                    }
                                    else
                                    {
                                        citizenInfo.m_citizenAI.SetSource(instance3, ref instance2.m_instances.m_buffer[(int)instance3], buildingID);
                                        citizenInfo.m_citizenAI.JoinTarget(instance3, ref instance2.m_instances.m_buffer[(int)instance3], otherInstance);
                                    }
                                    instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen1)].CurrentLocation = Citizen.Location.Moving;
                                }
                            }
                            else
                                break;
                        }
                    }
                }
            }
            if (flag1)
            {
                CitizenManager instance2 = Singleton<CitizenManager>.instance;
                ushort building = offer.Building;
                if ((int)building != 0)
                {
                    int family = Singleton<SimulationManager>.instance.m_randomizer.Int32(256U);
                    uint unitID = 0U;
                    if (!flag2)
                        unitID = instance1.m_buildings.m_buffer[(int)building].GetEmptyCitizenUnit(CitizenUnit.Flags.Visit);
                    if ((int)unitID != 0 || flag2)
                    {
                        int age = Singleton<SimulationManager>.instance.m_randomizer.Int32(45, 240);
                        Citizen.Wealth wealth = Citizen.Wealth.High;
                        int num2 = touristFactor0 + touristFactor1 + touristFactor2;
                        if (num2 != 0)
                        {
                            int num3 = Singleton<SimulationManager>.instance.m_randomizer.Int32((uint)num2);
                            if (num3 < touristFactor0)
                                wealth = Citizen.Wealth.Low;
                            else if (num3 < touristFactor0 + touristFactor1)
                                wealth = Citizen.Wealth.Medium;
                        }
                        uint citizen;
                        if (instance2.CreateCitizen(out citizen, age, family, ref Singleton<SimulationManager>.instance.m_randomizer))
                        {
                            instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen)].m_flags |= Citizen.Flags.Tourist;
                            instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen)].m_flags |= Citizen.Flags.MovingIn;
                            instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen)].WealthLevel = wealth;
                            if (flag2)
                                instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen)].m_flags |= Citizen.Flags.DummyTraffic;
                            else
                                instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen)].SetVisitplace(citizen, (ushort)0, unitID);
                            CitizenInfo citizenInfo = instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen)].GetCitizenInfo(citizen);
                            ushort instance3;
                            if (citizenInfo != null && instance2.CreateCitizenInstance(out instance3, ref Singleton<SimulationManager>.instance.m_randomizer, citizenInfo, citizen))
                            {
                                citizenInfo.m_citizenAI.SetSource(instance3, ref instance2.m_instances.m_buffer[(int)instance3], buildingID);
                                citizenInfo.m_citizenAI.SetTarget(instance3, ref instance2.m_instances.m_buffer[(int)instance3], building);
                                instance2.m_citizens.m_buffer[(int)((UIntPtr)citizen)].CurrentLocation = Citizen.Location.Moving;
                            }
                            if (!flag2)
                                Singleton<StatisticsManager>.instance.Acquire<StatisticArray>(StatisticType.IncomingTourists).Acquire<StatisticInt32>((int)wealth, 3).Add(1);
                        }
                    }
                }
            }
            if (info != null)
            {
                Array16<Vehicle> array16 = Singleton<VehicleManager>.instance.m_vehicles;
                ushort vehicle;
                if (Singleton<VehicleManager>.instance.CreateVehicle(out vehicle, ref Singleton<SimulationManager>.instance.m_randomizer, info, data.m_position, material, false, true))
                {
                    if (flag2)
                    {
                        array16.m_buffer[(int)vehicle].m_flags |= Vehicle.Flags.DummyTraffic;
                        array16.m_buffer[(int)vehicle].m_flags &= ~Vehicle.Flags.WaitingCargo;
                    }
                    info.m_vehicleAI.SetSource(vehicle, ref array16.m_buffer[(int)vehicle], buildingID);
                    info.m_vehicleAI.StartTransfer(vehicle, ref array16.m_buffer[(int)vehicle], material, offer);
                    if (!flag2)
                    {
                        ushort building = offer.Building;
                        if ((int)building != 0)
                        {
                            int size;
                            int max;
                            info.m_vehicleAI.GetSize(vehicle, ref array16.m_buffer[(int)vehicle], out size, out max);
                            CustomOutsideConnectionAI.ImportResource(building, ref Singleton<BuildingManager>.instance.m_buildings.m_buffer[(int)building], material, size);
                        }
                    }
                }
            }
            return true;
        }

        protected static void ImportResource(ushort buildingID, ref Building data, TransferManager.TransferReason resource, int amount)
        {
            byte district = Singleton<DistrictManager>.instance.GetDistrict(data.m_position);
            TransferManager.TransferReason transferReason = resource;
            switch (transferReason)
            {
                case TransferManager.TransferReason.Oil:
                    Singleton<DistrictManager>.instance.m_districts.m_buffer[(int)district].m_importData.m_tempOil += (uint)amount;
                    break;
                case TransferManager.TransferReason.Ore:
                case TransferManager.TransferReason.Coal:
                    Singleton<DistrictManager>.instance.m_districts.m_buffer[(int)district].m_importData.m_tempOre += (uint)amount;
                    break;
                case TransferManager.TransferReason.Logs:
                    Singleton<DistrictManager>.instance.m_districts.m_buffer[(int)district].m_importData.m_tempForestry += (uint)amount;
                    break;
                case TransferManager.TransferReason.Grain:
                    Singleton<DistrictManager>.instance.m_districts.m_buffer[(int)district].m_importData.m_tempAgricultural += (uint)amount;
                    break;
                case TransferManager.TransferReason.Goods:
                    Singleton<DistrictManager>.instance.m_districts.m_buffer[(int)district].m_importData.m_tempGoods += (uint)amount;
                    break;
                default:
                    if (transferReason != TransferManager.TransferReason.Petrol)
                    {
                        if (transferReason != TransferManager.TransferReason.Food)
                        {
                            if (transferReason != TransferManager.TransferReason.Lumber)
                                break;
                            goto case TransferManager.TransferReason.Logs;
                        }
                        else
                            goto case TransferManager.TransferReason.Grain;
                    }
                    else
                        goto case TransferManager.TransferReason.Oil;
            }
        }
    }
}
