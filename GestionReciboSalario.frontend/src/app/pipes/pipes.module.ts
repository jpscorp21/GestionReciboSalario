
import { ComaPipe } from './coma.pipe';
import { NgModule } from '@angular/core';
import { RolPipe } from './rol.pipe';
import { FirmaPipe } from './firma.pipe';


const pipes = [
    ComaPipe,
    RolPipe,
    FirmaPipe    
];

@NgModule({
    declarations: [...pipes],
    exports: [...pipes],
    imports: [],
})
export class PipesModule {}

