function solve(input){
    const numberOfSuperHeroes = Number(input.shift());
    const superHeroes = {};

    for(let i = 0; i < numberOfSuperHeroes; i++){
        const [superHeroName, superpowerInput, energyInput] = input.shift().split('-');
        const superPowers = superpowerInput.split(',');
        const energy = Number(energyInput);
        
        superHeroes[superHeroName] = {
            superPowers,
            energy
        }
    }
    
    let command = input.shift();
    while(command !== 'Evil Defeated!'){
        const [commandName, superHeroName, ...args] = command.split(' * ');

        switch (commandName) {
            case 'Use Power':
                const superpower = args[0];
                const energyRequired = Number(args[1]);

                if(superHeroes[superHeroName].energy >= energyRequired &&
                    superHeroes[superHeroName].superPowers.includes(superpower)
                ){
                    superHeroes[superHeroName].energy -= energyRequired;
                    console.log(`${superHeroName} has used ${superpower} and now has ${superHeroes[superHeroName].energy} energy!`);
                } else{
                    console.log(`${superHeroName} is unable to use ${superpower} or lacks energy!`);
                }
            break;
            case 'Train':
                const trainingEnergy = Number(args[0]);

                if(superHeroes[superHeroName].energy === 100){
                    console.log(`${superHeroName} is already at full energy!`); 
                    break; 
                }

                if(superHeroes[superHeroName].energy + trainingEnergy > 100){
                    const energyToFill = 100 - superHeroes[superHeroName].energy;
                    superHeroes[superHeroName].energy = 100;
                    console.log(`${superHeroName} has trained and gained ${energyToFill} energy!`);
                } else{
                    superHeroes[superHeroName].energy += trainingEnergy;
                    console.log(`${superHeroName} has trained and gained ${trainingEnergy} energy!`);           
                }
            break;
            case 'Learn':
                const newSuperPower = args[0];

                if(superHeroes[superHeroName].superPowers.includes(newSuperPower)){
                    console.log(`${superHeroName} already knows ${newSuperPower}.`);
                } else{
                    superHeroes[superHeroName].superPowers.push(newSuperPower);
                    console.log(`${superHeroName} has learned ${newSuperPower}!`); 
                }
            break;
        }

        command = input.shift();
    }

    Object.keys(superHeroes)
        .forEach(superHeroName => {
            const superPowersText = superHeroes[superHeroName].superPowers.join(', ').trim();
            console.log(`Superhero: ${superHeroName}`);
            console.log(` - Superpowers: ${superPowersText}`);
            console.log(` - Energy: ${superHeroes[superHeroName].energy}`);
        })
}

solve([
    "3",
    "Iron Man-Repulsor Beams,Flight-80",
    "Thor-Lightning Strike,Hammer Throw-10",
    "Hulk-Super Strength-60",
    "Use Power * Iron Man * Flight * 30",
    "Train * Thor * 20",
    "Train * Hulk * 50",
    "Learn * Hulk * Thunderclap",
    "Use Power * Hulk * Thunderclap * 70",
    "Evil Defeated!"
])
