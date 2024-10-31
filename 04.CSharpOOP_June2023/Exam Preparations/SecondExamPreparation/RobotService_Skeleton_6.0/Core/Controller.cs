using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IRepository<IRobot> robots;
        private IRepository<ISupplement> supplements;
        public Controller()
        {
            robots = new RobotRepository();
            supplements = new SupplementRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if(typeName == nameof(DomesticAssistant))
            {
                IRobot domesticAssistant = new DomesticAssistant(model);
                robots.AddNew(domesticAssistant);

            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                IRobot industrialAssistant = new IndustrialAssistant(model);
                robots.AddNew(industrialAssistant);
            }
            else
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            return $"{typeName} {model} is created and added to the RobotRepository.";
        }

        public string CreateSupplement(string typeName)
        {
            if(typeName == nameof(SpecializedArm))
            {
                ISupplement specializedArm = new SpecializedArm();
                supplements.AddNew(specializedArm);
            }
            else if (typeName == nameof(LaserRadar))
            {
                ISupplement laserRadar = new LaserRadar();
                supplements.AddNew(laserRadar);
            }
            else
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            return $"{typeName} is created and added to the SupplementRepository.";
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            IEnumerable<IRobot> filteredRobots = robots.Models()
                .Where(r => r.InterfaceStandards.Contains(intefaceStandard))
                .OrderByDescending(r => r.BatteryLevel);

            if (!filteredRobots.Any())
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int availablePower = filteredRobots.Sum(r => r.BatteryLevel);

            if(availablePower < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - availablePower);
            }

            int robotsCounter = 0;

            foreach(IRobot robot in filteredRobots)
            {
                if(robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    robotsCounter++;
                    break;
                }
                
                totalPowerNeeded -= robot.BatteryLevel;
                robot.ExecuteService(totalPowerNeeded);
                robotsCounter++;
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotsCounter); 
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            
            IEnumerable<IRobot> robotsFiltered = robots.Models()
                .OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity);

            foreach(IRobot robot in robotsFiltered)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        //public string RobotRecovery(string model, int minutes)
        //{
        //    IEnumerable<IRobot> robotsToRecover = robots
        //        .Models()
        //        .Where(r => r.Model == model && r.BatteryCapacity / 2 > r.BatteryLevel);

        //    int fedCount = 0;

        //    foreach(IRobot robot in robotsToRecover)
        //    {
        //        fedCount++;
        //        robot.Eating(minutes);               
        //    }

        //    return string.Format(OutputMessages.RobotsFed, fedCount);
        //}

        public string RobotRecovery(string model, int minutes)
        {
            IEnumerable<IRobot> robotsToRecover = robots
                .Models()
                .Where(r => r.Model == model && r.BatteryCapacity / 2 > r.BatteryLevel);

            int fedCount = 0;

            foreach (IRobot robot in robotsToRecover)
            {
                fedCount++;
                robot.Eating(minutes);
            }

            return string.Format(OutputMessages.RobotsFed, fedCount);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models()
                .First(s => s.GetType().Name == supplementTypeName);

            IRobot robot = robots.Models()
                .FirstOrDefault(r => r.Model == model 
                && !r.InterfaceStandards.Contains(supplement.InterfaceStandard));

            if(robot == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            
            robot.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
    }
}
