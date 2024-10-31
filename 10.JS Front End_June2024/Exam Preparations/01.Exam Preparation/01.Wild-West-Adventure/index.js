function solve(input){
    const numberOfCharacters = Number(input.shift());
    const posse = {};

    for(let i = 0; i < numberOfCharacters; i++){
        const [heroName, hpInput, bulletsInput] = input.shift().split(' ');
        const hp = Number(hpInput);
        const bullets = Number(bulletsInput);

        posse[heroName] = {
            hp,
            bullets
        }
    }

    const commands = {
        FireShot(characterName, target){
            if(posse[characterName].bullets > 0){
                const currentBullets = --posse[characterName].bullets;
                console.log(`${characterName} has successfully hit ${target} and now has ${currentBullets} bullets!`);
            } else {
                console.log(`${characterName} doesn't have enough bullets to shoot at ${target}!`);
            }
        },
        TakeHit(characterName, damage, attacker){
            posse[characterName].hp -= damage;
            const currentHp = posse[characterName].hp;
            if(currentHp > 0){
                console.log(`${characterName} took a hit for ${damage} HP from ${attacker} and now has ${currentHp} HP!`);
                
            } else {
                delete posse[characterName];
                console.log(`${characterName} was gunned down by ${attacker}!`);
            }
        },
        Reload(characterName){
            const currentBullets = posse[characterName].bullets;
            if(currentBullets < 6){
                posse[characterName].bullets = 6;
                console.log(`${characterName} reloaded ${6 - currentBullets} bullets!`);    
            } else {
                console.log(`${characterName}'s pistol is fully loaded!`);  
            }
        },
        PatchUp(characterName, amount){
            const currentHp = posse[characterName].hp;
            const newHp = Math.min(currentHp + Number(amount), 100);

            if(newHp < 100){
                posse[characterName].hp = newHp;
                console.log(`${characterName} patched up and recovered ${amount} HP!`);    
            } else {
                posse[characterName].hp = 100;
                console.log(`${characterName} is in full health!`);     
            }
        }
    }

    let command = input.shift();
    while(command != 'Ride Off Into Sunset'){
        const [commandName, characterName, ...args] = command.split(' - ');

        commands[commandName](characterName, ...args);

        command = input.shift();
    }

    Object.keys(posse)
        .forEach(characterName => {
            console.log(`${characterName}`);
            console.log(` HP: ${posse[characterName].hp}`);
            console.log(` Bullets: ${posse[characterName].bullets}`);
        })
}

solve(["2",
    "Gus 100 4",
    "Walt 100 5",
    "FireShot - Gus - Bandit",
    "TakeHit - Walt - 100 - Bandit",
    "Reload - Gus",
    "Ride Off Into Sunset"])
 
 