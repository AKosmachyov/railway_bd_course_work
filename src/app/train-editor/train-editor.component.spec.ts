import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainEditorComponent } from './train-editor.component';

describe('TrainEditorComponent', () => {
  let component: TrainEditorComponent;
  let fixture: ComponentFixture<TrainEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrainEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
