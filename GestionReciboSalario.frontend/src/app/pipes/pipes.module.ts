
import { ComaPipe } from './coma.pipe';
import { NgModule } from '@angular/core';


const pipes = [
    ComaPipe,    
];

@NgModule({
    declarations: [...pipes],
    exports: [...pipes],
    imports: [],
})
export class PipesModule {}

