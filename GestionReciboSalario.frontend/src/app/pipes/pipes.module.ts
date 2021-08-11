
import { ComaPipe } from './coma.pipe';
import { NgModule } from '@angular/core';
import { RolPipe } from './rol.pipe';


const pipes = [
    ComaPipe,
    RolPipe    
];

@NgModule({
    declarations: [...pipes],
    exports: [...pipes],
    imports: [],
})
export class PipesModule {}

