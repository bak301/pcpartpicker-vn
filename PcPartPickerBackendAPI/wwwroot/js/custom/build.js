'use strict';

class Build {
    constructor(name) {
        this.name = name;
        if (localStorage[name] === undefined) {
            localStorage[name] = JSON.stringify({
            });
        }

        this.currentBuild = JSON.parse(localStorage[name])
    }

    add(partType, part) {
        switch (partType) {
            case 'cpu':
            case 'motherboard':
            case 'pccase':
            case 'powersupply':
                this.currentBuild[partType] = part;
                break;
            case 'memory':
            case 'storage':
            case 'gpu':
                if (!this.currentBuild.hasOwnProperty(partType)) {
                    this.currentBuild[partType] = [];
                }
                this.currentBuild[partType].push(part);
                break;
            default:
                break;
        }
        this.update();
    }

    remove(partType) {
        delete this.currentBuild[partType];
        this.update();
    }

    removeSingle(partType, partId) {
        this.currentBuild[partType].splice(this.currentBuild[partType].findIndex(i => i.id = partId), 1);
        this.update();
    }

    clear() {
        this.currentBuild = {};
        this.update();
    }

    finalize(){
        this.currentBuild.date = new Date();
        this.update();
    }

    update() {
        localStorage[this.name] = JSON.stringify(this.currentBuild);
    }
}