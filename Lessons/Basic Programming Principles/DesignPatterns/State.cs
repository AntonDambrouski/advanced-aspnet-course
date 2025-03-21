using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Programming_Principles.DesignPatterns
{
    public enum State { Draft, Moderation, Published }
    public class Document
    {
        private State _state = State.Draft;

        public void Publish()
        {
            if (_state == State.Draft)
            {
                _state = State.Moderation;
                Console.WriteLine("Документ отправлен на модерацию.");
            }
            else if (_state == State.Moderation)
            {
                _state = State.Published;
                Console.WriteLine("Документ опубликован.");
            }
            else
            {
                Console.WriteLine("Публикация невозможна.");
            }
        }
    }

    public interface IDocumentState
    {
        void Publish(DocumentBetter document);
    }

    public class DocumentBetter
    {
        private IDocumentState _state;

        public DocumentBetter() => _state = new DraftState();

        public void SetState(IDocumentState state)
        {
            _state = state;
        }

        public void Publish()
        {
            _state.Publish(this);
        }
    }

    public class DraftState : IDocumentState
    {
        public void Publish(DocumentBetter document)
        {
            Console.WriteLine("Документ отправлен на модерацию.");
            document.SetState(new ModerationState());
        }
    }

    public class ModerationState : IDocumentState
    {
        public void Publish(DocumentBetter document)
        {
            Console.WriteLine("Документ опубликован.");
            document.SetState(new PublishedState());
        }
    }

    public class PublishedState : IDocumentState
    {
        public void Publish(DocumentBetter document)
        {
            Console.WriteLine("Публикация невозможна.");
        }
    }

    static class StateDemo
    {
        public static void Execute()
        {
            Document document = new Document();
            document.Publish();


            DocumentBetter documentBetter = new DocumentBetter();
            documentBetter.Publish();
            documentBetter.Publish();
            documentBetter.Publish();
        }
    }
}
